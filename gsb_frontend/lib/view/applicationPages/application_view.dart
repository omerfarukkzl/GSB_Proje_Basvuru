import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application/application_bloc.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application/application_event.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application/application_state.dart';
import 'package:intl/intl.dart';

class ApplicationPage extends StatefulWidget {
  @override
  _ApplicationPageState createState() => _ApplicationPageState();
}

class _ApplicationPageState extends State<ApplicationPage> {
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
    context.read<ApplicationBloc>().add(LoadDropdownData());
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

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Başvuru'),
        centerTitle: true,
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(24.0),
          child: BlocListener<ApplicationBloc, ApplicationState>(
            listener: (context, state) {
              if (state is ApplicationSubmitted) {
                ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(content: Text('Başvuru başarıyla gönderildi')),
                );
                Navigator.pushReplacementNamed(context, '/applicationList');
                _formKey.currentState!.reset();
              } else if (state is ApplicationError) {
                ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(content: Text(state.message)),
                );
              }
            },
            child: BlocBuilder<ApplicationBloc, ApplicationState>(
              builder: (context, state) {
                if (state is ApplicationLoading) {
                  return const Center(child: CircularProgressIndicator());
                } else if (state is ApplicationLoaded) {
                  return buildForm(state, context);
                } else {
                  return SizedBox();
                }
              },
            ),
          ),
        ),
      ),
    );
  }

  Form buildForm(ApplicationLoaded state, BuildContext context) {
    return Form(
      key: _formKey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: [
          Center(
            child: Column(
              children: [
                Icon(
                  Icons.assignment,
                  size: 100,
                  color: Colors.blueAccent,
                ),
                SizedBox(height: 20),
                Text(
                  'Yeni Başvuru',
                  style: TextStyle(
                    fontSize: 24,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ],
            ),
          ),
          SizedBox(height: 40),
          buildTextFormField(
            controller: _projeAdiController,
            labelText: 'Proje Adı',
            icon: Icons.work,
            validator: (value) =>
                value == null || value.isEmpty ? 'Proje Adı gerekli' : null,
          ),
          SizedBox(height: 20),
          buildDropdownFormField(
            value: selectedBasvuranBirim,
            labelText: 'Başvuran Birimi',
            items: state.dropdownData['basvuranBirimler'],
            onChanged: (value) => setState(() => selectedBasvuranBirim = value),
          ),
          SizedBox(height: 20),
          buildDropdownFormField(
            value: selectedBasvuruYapilanProje,
            labelText: 'Başvuru Yapılan Proje',
            items: state.dropdownData['basvuruYapilanProje'],
            onChanged: (value) =>
                setState(() => selectedBasvuruYapilanProje = value),
          ),
          SizedBox(height: 20),
          buildDropdownFormField(
            value: selectedBasvuruYapilanTur,
            labelText: 'Başvuru Yapılan Tür',
            items: state.dropdownData['basvuruYapilanTur'],
            onChanged: (value) =>
                setState(() => selectedBasvuruYapilanTur = value),
          ),
          SizedBox(height: 20),
          buildDropdownFormField(
            value: selectedKatilimciTur,
            labelText: 'Katılımcı Türü',
            items: state.dropdownData['katilimciTurleri'],
            onChanged: (value) => setState(() => selectedKatilimciTur = value),
          ),
          SizedBox(height: 20),
          buildDropdownFormField(
            value: selectedBasvuruDonem,
            labelText: 'Başvuru Dönemi',
            items: state.dropdownData['basvuruDonemleri'],
            onChanged: (value) => setState(() => selectedBasvuruDonem = value),
          ),
          SizedBox(height: 20),
          buildDropdownFormField(
            value: selectedBasvuruDurum,
            labelText: 'Başvuru Durumu',
            items: state.dropdownData['basvuruDurumlari'],
            onChanged: (value) => setState(() => selectedBasvuruDurum = value),
          ),
          SizedBox(height: 20),
          buildDateFormField(
            controller: _basvuruTarihiController,
            labelText: 'Başvuru Tarihi',
            onTap: () => datePickerFunction(context: context),
            validator: (value) => value == null || value.isEmpty
                ? 'Başvuru Tarihi gerekli'
                : null,
          ),
          SizedBox(height: 20),
          buildDateFormField(
            controller: _aciklanmaTarihiController,
            labelText: 'Açıklanma Tarihi',
            onTap: () => datePickerFunction(context: context),
            validator: (value) => value == null || value.isEmpty
                ? 'Açıklanma Tarihi gerekli'
                : null,
          ),
          SizedBox(height: 20),
          buildTextFormField(
            controller: _hibeTutariController,
            labelText: 'Hibe Tutarı',
            icon: Icons.attach_money,
            keyboardType: TextInputType.number,
            validator: (value) =>
                value == null || value.isEmpty ? 'Hibe Tutarı gerekli' : null,
          ),
          SizedBox(height: 30),
          ElevatedButton(
            onPressed: () {
              if (_formKey.currentState!.validate()) {
                final applicationData = {
                  'projeAdi': _projeAdiController.text,
                  'basvuranBirimId': selectedBasvuranBirim,
                  'basvuruYapilanProjeId': selectedBasvuruYapilanProje,
                  'basvuruYapilanTurId': selectedBasvuruYapilanTur,
                  'katilimciTurId': selectedKatilimciTur,
                  'basvuruDonemId': selectedBasvuruDonem,
                  'basvuruDurumId': selectedBasvuruDurum,
                  'hibeTutari': double.parse(_hibeTutariController.text),
                  'basvuruTarihi': _basvuruTarihiController.text,
                  'aciklanmaTarihi': _aciklanmaTarihiController.text,
                };
                context
                    .read<ApplicationBloc>()
                    .add(SubmitApplication(applicationData));
              }
            },
            style: ElevatedButton.styleFrom(
              padding: EdgeInsets.symmetric(vertical: 16.0),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(8),
              ),
            ),
            child: const Text(
              'Başvuru Yap',
              style: TextStyle(fontSize: 18),
            ),
          ),
        ],
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
}
