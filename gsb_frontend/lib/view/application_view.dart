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
      appBar: AppBar(title: Text('Başvuru')),
      body: BlocListener<ApplicationBloc, ApplicationState>(
        listener: (context, state) {
          if (state is ApplicationSubmitted) {
            ScaffoldMessenger.of(context).showSnackBar(
              SnackBar(content: Text('Başvuru başarıyla gönderildi')),
            );
            Navigator.pushReplacementNamed(context, '/applicationList');
            _formKey.currentState!.reset();
          } else if (state is ApplicationError) {
            print(state.message);
          }
        },
        child: BlocBuilder<ApplicationBloc, ApplicationState>(
          builder: (context, state) {
            print('test : ${state}');
            if (state is ApplicationLoading) {
              return const Center(child: CircularProgressIndicator());
            } else if (state is ApplicationLoaded) {
              return Padding(
                padding: const EdgeInsets.all(16.0),
                child: buildForm(state, context),
              );
            } else {
              return SizedBox();
              ;
            }
          },
        ),
      ),
    );
  }

  Form buildForm(ApplicationLoaded state, BuildContext context) {
    return Form(
      key: _formKey,
      child: ListView(
        children: [
          TextFormField(
            controller: _projeAdiController,
            decoration: InputDecoration(labelText: 'Proje Adı'),
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Proje Adı gerekli';
              }
              return null;
            },
          ),
          DropdownButtonFormField<String>(
            value: selectedBasvuranBirim,
            decoration: InputDecoration(labelText: 'Başvuran Birimi'),
            items: state.dropdownData['basvuranBirimler']
                .map<DropdownMenuItem<String>>((item) {
              return DropdownMenuItem<String>(
                value: item['id'].toString(),
                child: Text(item['ad']),
              );
            }).toList(),
            onChanged: (value) {
              setState(() {
                selectedBasvuranBirim = value;
              });
            },
          ),
          DropdownButtonFormField<String>(
            value: selectedBasvuruYapilanProje,
            decoration: InputDecoration(labelText: 'Başvuru Yapılan Proje'),
            items: state.dropdownData['basvuruYapilanProje']
                .map<DropdownMenuItem<String>>((item) {
              return DropdownMenuItem<String>(
                value: item['id'].toString(),
                child: Text(item['ad']),
              );
            }).toList(),
            onChanged: (value) {
              setState(() {
                selectedBasvuruYapilanProje = value;
              });
            },
          ),
          DropdownButtonFormField<String>(
            value: selectedBasvuruYapilanTur,
            decoration: InputDecoration(labelText: 'Başvuru Yapılan Tür'),
            items: state.dropdownData['basvuruYapilanTur']
                .map<DropdownMenuItem<String>>((item) {
              return DropdownMenuItem<String>(
                value: item['id'].toString(),
                child: Text(item['ad']),
              );
            }).toList(),
            onChanged: (value) {
              setState(() {
                selectedBasvuruYapilanTur = value;
              });
            },
          ),
          DropdownButtonFormField<String>(
            value: selectedKatilimciTur,
            decoration: InputDecoration(labelText: 'Katılımcı Türü'),
            items: state.dropdownData['katilimciTurleri']
                .map<DropdownMenuItem<String>>((item) {
              return DropdownMenuItem<String>(
                value: item['id'].toString(),
                child: Text(item['ad']),
              );
            }).toList(),
            onChanged: (value) {
              setState(() {
                selectedKatilimciTur = value;
              });
            },
          ),
          DropdownButtonFormField<String>(
            value: selectedBasvuruDonem,
            decoration: InputDecoration(labelText: 'Başvuru Dönemi'),
            items: state.dropdownData['basvuruDonemleri']
                .map<DropdownMenuItem<String>>((item) {
              return DropdownMenuItem<String>(
                value: item['id'].toString(),
                child: Text(item['ad']),
              );
            }).toList(),
            onChanged: (value) {
              setState(() {
                selectedBasvuruDonem = value;
              });
            },
          ),
          DropdownButtonFormField<String>(
            value: selectedBasvuruDurum,
            decoration: InputDecoration(labelText: 'Başvuru Durumu'),
            items: state.dropdownData['basvuruDurumlari']
                .map<DropdownMenuItem<String>>((item) {
              return DropdownMenuItem<String>(
                value: item['id'].toString(),
                child: Text(item['ad']),
              );
            }).toList(),
            onChanged: (value) {
              setState(() {
                selectedBasvuruDurum = value;
              });
            },
          ),
          TextFormField(
            controller: _basvuruTarihiController,
            decoration: InputDecoration(labelText: 'Başvuru Tarihi'),
            readOnly: true,
            onTap: () async {
              DateTime? pickedDate = await showDatePicker(
                context: context,
                initialDate: DateTime.now(),
                firstDate: DateTime(2000),
                lastDate: DateTime(2101),
              );
              if (pickedDate != null) {
                setState(() {
                  _basvuruTarihiController.text =
                      pickedDate.toUtc().toIso8601String();
                });
              }
            },
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Başvuru Tarihi gerekli';
              }
              return null;
            },
          ),
          TextFormField(
            controller: _aciklanmaTarihiController,
            decoration: InputDecoration(labelText: 'Açıklanma Tarihi'),
            readOnly: true,
            onTap: () async {
              DateTime? pickedDate = await showDatePicker(
                context: context,
                initialDate: DateTime.now(),
                firstDate: DateTime(2000),
                lastDate: DateTime(2101),
              );
              if (pickedDate != null) {
                setState(() {
                  _aciklanmaTarihiController.text =
                      pickedDate.toUtc().toIso8601String();
                  print(_aciklanmaTarihiController.text);
                });
              }
            },
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Açıklanma Tarihi gerekli';
              }
              return null;
            },
          ),
          TextFormField(
            controller: _hibeTutariController,
            decoration: InputDecoration(labelText: 'Hibe Tutarı'),
            keyboardType: TextInputType.number,
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Hibe Tutarı gerekli';
              }
              return null;
            },
          ),
          SizedBox(height: 20),
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
            child: Text('Başvuru Yap'),
          ),
        ],
      ),
    );
  }
}
