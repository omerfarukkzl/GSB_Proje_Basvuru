import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application-list/application_list_bloc.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application-list/application_list_event.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application-list/application_list_state.dart';
import 'package:intl/intl.dart';

class ApplicationListPage extends StatefulWidget {
  const ApplicationListPage({super.key});

  @override
  State<ApplicationListPage> createState() => _ApplicationListPageState();
}

class _ApplicationListPageState extends State<ApplicationListPage> {
  final _formKey = GlobalKey<FormState>();
  final TextEditingController _projeAdiController = TextEditingController();
  final TextEditingController _hibeTutariController = TextEditingController();
  final TextEditingController _basvuruTarihiController =
      TextEditingController();
  final TextEditingController _aciklanmaTarihiController =
      TextEditingController();
  String? selectedBasvuranBirim;
  String? selectedBasvuruYapilanProje;
  String? selectedBasvuruYapilanTur;
  String? selectedKatilimciTur;
  String? selectedBasvuruDonem;
  String? selectedBasvuruDurum;

  @override
  void initState() {
    super.initState();
    context.read<ApplicationListBloc>().add(LoadApplications());
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Başvuru Listesi'),
        actions: [
          IconButton(
            icon: Icon(Icons.filter_list),
            onPressed: () => _openFilterDialog(context),
          ),
        ],
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.restorablePushReplacementNamed(context, '/application');
        },
        child: Icon(Icons.add),
      ),
      body: BlocBuilder<ApplicationListBloc, ApplicationListState>(
        builder: (context, state) {
          if (state is ApplicationListLoading) {
            return Center(child: CircularProgressIndicator());
          } else if (state is ApplicationListLoaded) {
            return RefreshIndicator(
              onRefresh: () async {
                context.read<ApplicationListBloc>().add(LoadApplications());
              },
              child: SingleChildScrollView(
                scrollDirection: Axis.horizontal,
                child: DataTable(
                  columns: [
                    DataColumn(label: Text('Proje Adı')),
                    DataColumn(label: Text('Başvuran Birim')),
                    DataColumn(label: Text('Başvuru Yapılan Proje')),
                    DataColumn(label: Text('Başvuru Yapılan Tür')),
                    DataColumn(label: Text('Katılımcı Türü')),
                    DataColumn(label: Text('Başvuru Dönemi')),
                    DataColumn(label: Text('Başvuru Tarihi')),
                    DataColumn(label: Text('Durum')),
                  ],
                  rows: state.applications.map<DataRow>((application) {
                    return DataRow(
                      cells: [
                        DataCell(
                            Text(application['projeAdi'] ?? 'Proje Adı Yok')),
                        DataCell(Text(application['basvuranBirimAdi'] ??
                            'Birim Adı Yok')),
                        DataCell(Text(application['basvuruYapilanProjeAdi'] ??
                            'Proje Adı Yok')),
                        DataCell(Text(application['basvuruYapilanTurAdi'] ??
                            'Tür Adı Yok')),
                        DataCell(Text(application['katilimciTurAdi'] ??
                            'Katılımcı Türü Yok')),
                        DataCell(Text(
                            application['basvuruDonemAdi'] ?? 'Dönem Adı Yok')),
                        DataCell(Text(
                            application['basvuruTarihi']?.split('T').first ??
                                'Tarih Yok')),
                        DataCell(Text(
                            application['basvuruDurumAdi'] ?? 'Durum Adı Yok')),
                      ],
                    );
                  }).toList(),
                ),
              ),
            );
          } else if (state is ApplicationListError) {
            return Center(child: Text(state.message));
          } else {
            return Center(child: Text('Başvurular yüklenemedi.'));
          }
        },
      ),
    );
  }

  void _openFilterDialog(BuildContext context) {
    context.read<ApplicationListBloc>().add(LoadFilterList());

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return BlocBuilder<ApplicationListBloc, ApplicationListState>(
          builder: (context, state) {
            if (state is FilterListLoaded) {
              return SingleChildScrollView(
                child: AlertDialog(
                  title: Text('Filtrele'),
                  content: buildForm(state, context),
                  actions: [
                    TextButton(
                      onPressed: () {
                        // Filtreleri temizle
                        _projeAdiController.clear();
                        _hibeTutariController.clear();
                        _basvuruTarihiController.clear();
                        _aciklanmaTarihiController.clear();
                        setState(() {
                          selectedBasvuranBirim = null;
                          selectedBasvuruYapilanProje = null;
                          selectedBasvuruYapilanTur = null;
                          selectedKatilimciTur = null;
                          selectedBasvuruDonem = null;
                          selectedBasvuruDurum = null;
                        });
                        context
                            .read<ApplicationListBloc>()
                            .add(LoadApplications());
                        Navigator.of(context).pop();
                      },
                      child: Text('Temizle'),
                    ),
                    TextButton(
                      onPressed: () {
                        final queryParameters = {
                          'projeAdi': _projeAdiController.text,
                          'basvuranBirimId': selectedBasvuranBirim,
                          'basvuruYapilanProjeId': selectedBasvuruYapilanProje,
                          'basvuruYapilanTurId': selectedBasvuruYapilanTur,
                          'katilimciTurId': selectedKatilimciTur,
                          'basvuruDonemId': selectedBasvuruDonem,
                          'basvuruDurumId': selectedBasvuruDurum,
                          'basvuruTarihi': _basvuruTarihiController.text,
                          'aciklanmaTarihi': _aciklanmaTarihiController.text,
                        };

                        final filteredQueryParameters = Map.fromEntries(
                            queryParameters.entries.where(
                                (entry) => entry.value?.isNotEmpty == true));

                        print(
                            'Filtered Query Parameters: $filteredQueryParameters');
                        context
                            .read<ApplicationListBloc>()
                            .add(LoadApplications(filteredQueryParameters));
                        Navigator.of(context).pop();
                      },
                      child: Text('Uygula'),
                    ),
                  ],
                ),
              );
            } else if (state is ApplicationListLoading) {
              return Center(child: CircularProgressIndicator());
            } else {
              return AlertDialog(
                title: Text('Filtreler Yüklenemedi'),
                content: Text('Lütfen daha sonra tekrar deneyin.'),
                actions: [
                  TextButton(
                    onPressed: () {
                      Navigator.of(context).pop();
                      context
                          .read<ApplicationListBloc>()
                          .add(LoadApplications());
                    },
                    child: Text('Kapat'),
                  ),
                ],
              );
            }
          },
        );
      },
    );
  }

  Form buildForm(FilterListLoaded state, BuildContext context) {
    return Form(
      child: Container(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            buildTextFormField(
              controller: _projeAdiController,
              labelText: 'Proje Adı',
              icon: Icons.work,
              validator: (value) =>
                  value == null || value.isEmpty ? 'Proje Adı gerekli' : null,
            ),
            SizedBox(height: 10),
            buildDropdownFormField(
              value: selectedBasvuranBirim,
              labelText: 'Başvuran Birimi',
              items: state.dropdownData['basvuranBirimler'],
              onChanged: (value) =>
                  setState(() => selectedBasvuranBirim = value),
            ),
            SizedBox(height: 10),
            buildDropdownFormField(
              value: selectedBasvuruYapilanProje,
              labelText: 'Başvuru Yapılan Proje',
              items: state.dropdownData['basvuruYapilanProje'],
              onChanged: (value) =>
                  setState(() => selectedBasvuruYapilanProje = value),
            ),
            SizedBox(height: 10),
            buildDropdownFormField(
              value: selectedBasvuruYapilanTur,
              labelText: 'Başvuru Yapılan Tür',
              items: state.dropdownData['basvuruYapilanTur'],
              onChanged: (value) =>
                  setState(() => selectedBasvuruYapilanTur = value),
            ),
            SizedBox(height: 10),
            buildDropdownFormField(
              value: selectedKatilimciTur,
              labelText: 'Katılımcı Türü',
              items: state.dropdownData['katilimciTurleri'],
              onChanged: (value) =>
                  setState(() => selectedKatilimciTur = value),
            ),
            SizedBox(height: 10),
            buildDropdownFormField(
              value: selectedBasvuruDonem,
              labelText: 'Başvuru Dönemi',
              items: state.dropdownData['basvuruDonemleri'],
              onChanged: (value) =>
                  setState(() => selectedBasvuruDonem = value),
            ),
            SizedBox(height: 10),
            buildDropdownFormField(
              value: selectedBasvuruDurum,
              labelText: 'Başvuru Durumu',
              items: state.dropdownData['basvuruDurumlari'],
              onChanged: (value) =>
                  setState(() => selectedBasvuruDurum = value),
            ),
            SizedBox(height: 10),
            buildDateFormField(
              controller: _basvuruTarihiController,
              labelText: 'Başvuru Tarihi',
              onTap: () => datePickerFunction(context: context),
              validator: (value) => value == null || value.isEmpty
                  ? 'Başvuru Tarihi gerekli'
                  : null,
            ),
            SizedBox(height: 10),
            buildDateFormField(
              controller: _aciklanmaTarihiController,
              labelText: 'Açıklanma Tarihi',
              onTap: () => datePickerFunction(context: context),
              validator: (value) => value == null || value.isEmpty
                  ? 'Açıklanma Tarihi gerekli'
                  : null,
            ),
            SizedBox(height: 10),
          ],
        ),
      ),
    );
  }

  Widget buildTextFormField({
    required TextEditingController controller,
    required String labelText,
    IconData? icon,
    TextInputType? keyboardType,
    String? Function(String?)? validator,
  }) {
    return TextFormField(
      controller: controller,
      decoration: InputDecoration(
        labelText: labelText,
        prefixIcon: icon != null ? Icon(icon) : null,
        border: OutlineInputBorder(),
      ),
      keyboardType: keyboardType,
      validator: validator,
    );
  }

  Widget buildDropdownFormField({
    required String? value,
    required String labelText,
    required List<dynamic> items,
    required ValueChanged<String?> onChanged,
  }) {
    return DropdownButtonFormField<String>(
      value: value,
      decoration: InputDecoration(
        labelText: labelText,
        border: OutlineInputBorder(),
        prefixIcon: Icon(Icons.arrow_drop_down),
      ),
      items: items.map<DropdownMenuItem<String>>((item) {
        return DropdownMenuItem<String>(
          value: item['id'].toString(),
          child: Text(item['ad']),
        );
      }).toList(),
      onChanged: onChanged,
      validator: (value) => value == null ? 'Bu alan gerekli' : null,
    );
  }

  Widget buildDateFormField({
    required TextEditingController controller,
    required String labelText,
    required VoidCallback onTap,
    String? Function(String?)? validator,
  }) {
    return TextFormField(
      controller: controller,
      decoration: InputDecoration(
        labelText: labelText,
        prefixIcon: Icon(Icons.calendar_today),
        border: OutlineInputBorder(),
      ),
      readOnly: true,
      onTap: onTap,
      validator: validator,
    );
  }

  datePickerFunction({required BuildContext context}) async {
    DateTime? pickedDate = await showDatePicker(
      context: context,
      lastDate: DateTime.now(),
      firstDate: DateTime(2015),
      initialDate: DateTime.now(),
    );
    if (pickedDate == null) return;
    _basvuruTarihiController.text = DateFormat('yyyy-MM-dd').format(pickedDate);
  }
}
