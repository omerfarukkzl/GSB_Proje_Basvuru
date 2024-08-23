import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/Bloc/BasvuruBloc/basvuru_Bloc.dart';
import 'package:gsb_frontend/Bloc/BasvuruBloc/basvuru_Event.dart';
import 'package:gsb_frontend/Bloc/BasvuruBloc/basvuru_State.dart';
import 'package:gsb_frontend/Models/basvuru_model.dart';

class BasvuruForm extends StatelessWidget {
  final TextEditingController projeAdiController = TextEditingController();
  final TextEditingController hibeTutariController = TextEditingController();
  String? selectedBasvuruProje;
  String? selectedBasvuruTur;
  String? selectedBasvuranBirim;
  String? selectedKatilimciTuru;
  String? selectedBasvuruDonemi;
  DateTime? aciklamaTarihi;

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (_) => BasvuruBloc()..add(LoadComboBoxData()),
      child: Scaffold(
        appBar: AppBar(
          title: Text('Başvuru İşlemleri'),
        ),
        drawer: _buildDrawer(context),
        body: BlocListener<BasvuruBloc, BasvuruState>(
          listener: (context, state) {
            if (state is BasvuruSuccess) {
              ScaffoldMessenger.of(context).showSnackBar(
                SnackBar(content: Text('Başvuru başarıyla tamamlandı')),
              );
            } else if (state is BasvuruFailure) {
              ScaffoldMessenger.of(context).showSnackBar(
                SnackBar(content: Text('Başvuru başarısız oldu')),
              );
            }
          },
          child: BlocBuilder<BasvuruBloc, BasvuruState>(
            builder: (context, state) {
              if (state is BasvuruLoading) {
                return Center(child: CircularProgressIndicator());
              } else if (state is ComboBoxDataLoaded) {
                return Padding(
                  padding: const EdgeInsets.all(16.0),
                  child: ListView(
                    children: [
                      TextField(
                        controller: projeAdiController,
                        decoration: InputDecoration(labelText: 'Proje Adı'),
                      ),
                      SizedBox(height: 16.0),
                      DropdownButtonFormField<String>(
                        decoration:
                            InputDecoration(labelText: 'Başvuru Yapılan Proje'),
                        items: state.basvuruProjeList.map((String value) {
                          return DropdownMenuItem<String>(
                            value: value,
                            child: Text(value),
                          );
                        }).toList(),
                        onChanged: (newValue) {
                          selectedBasvuruProje = newValue;
                        },
                      ),
                      SizedBox(height: 16.0),
                      DropdownButtonFormField<String>(
                        decoration:
                            InputDecoration(labelText: 'Başvuru Yapılan Tür'),
                        items: state.basvuruTurList.map((String value) {
                          return DropdownMenuItem<String>(
                            value: value,
                            child: Text(value),
                          );
                        }).toList(),
                        onChanged: (newValue) {
                          selectedBasvuruTur = newValue;
                        },
                      ),
                      SizedBox(height: 16.0),
                      DropdownButtonFormField<String>(
                        decoration:
                            InputDecoration(labelText: 'Başvuran Birim'),
                        items: state.basvuranBirimList.map((String value) {
                          return DropdownMenuItem<String>(
                            value: value,
                            child: Text(value),
                          );
                        }).toList(),
                        onChanged: (newValue) {
                          selectedBasvuranBirim = newValue;
                        },
                      ),
                      SizedBox(height: 16.0),
                      DropdownButtonFormField<String>(
                        decoration:
                            InputDecoration(labelText: 'Katılımcı Türü'),
                        items: state.katilimciTuruList.map((String value) {
                          return DropdownMenuItem<String>(
                            value: value,
                            child: Text(value),
                          );
                        }).toList(),
                        onChanged: (newValue) {
                          selectedKatilimciTuru = newValue;
                        },
                      ),
                      SizedBox(height: 16.0),
                      DropdownButtonFormField<String>(
                        decoration:
                            InputDecoration(labelText: 'Başvuru Dönemi'),
                        items: state.basvuruDonemiList.map((String value) {
                          return DropdownMenuItem<String>(
                            value: value,
                            child: Text(value),
                          );
                        }).toList(),
                        onChanged: (newValue) {
                          selectedBasvuruDonemi = newValue;
                        },
                      ),
                      SizedBox(height: 16.0),
                      TextField(
                        controller: hibeTutariController,
                        decoration: InputDecoration(labelText: 'Hibe Tutarı'),
                        keyboardType: TextInputType.number,
                      ),
                      SizedBox(height: 16.0),
                      ElevatedButton(
                        onPressed: () {
                          if (selectedBasvuruProje != null &&
                              selectedBasvuruTur != null &&
                              selectedBasvuranBirim != null &&
                              selectedKatilimciTuru != null &&
                              selectedBasvuruDonemi != null) {
                            context.read<BasvuruBloc>().add(
                                  SubmitBasvuru(
                                    Basvuru(
                                      projeAdi: projeAdiController.text,
                                      basvuruYapilanProje:
                                          selectedBasvuruProje!,
                                      basvuruYapilanTur: selectedBasvuruTur!,
                                      basvuranBirim: selectedBasvuranBirim!,
                                      katilimciTuru: selectedKatilimciTuru!,
                                      basvuruDonemi: selectedBasvuruDonemi!,
                                      aciklamaTarihi: DateTime.now(),
                                      hibeTutari: double.tryParse(
                                              hibeTutariController.text) ??
                                          0.0,
                                    ),
                                  ),
                                );
                          } else {
                            ScaffoldMessenger.of(context).showSnackBar(
                              SnackBar(
                                  content: Text(
                                      'Lütfen tüm alanları doldurduğunuzdan emin olun.')),
                            );
                          }
                        },
                        child: Text('Başvuru Yap'),
                      ),
                    ],
                  ),
                );
              } else {
                return Center(child: Text('Veriler Yükleniyor...'));
              }
            },
          ),
        ),
      ),
    );
  }

  // Drawer (Sol Menü) Yapısı
  Widget _buildDrawer(BuildContext context) {
    return Drawer(
      child: ListView(
        padding: EdgeInsets.zero,
        children: <Widget>[
          DrawerHeader(
            decoration: BoxDecoration(
              color: Colors.blue,
            ),
            child: Text(
              'GSB Menü',
              style: TextStyle(
                color: Colors.white,
                fontSize: 24,
              ),
            ),
          ),
          ListTile(
            leading: Icon(Icons.home),
            title: Text('Başvuru İşlemleri'),
            onTap: () {
              // Başvuru İşlemleri sayfasına yönlendirme
              Navigator.pushReplacementNamed(context, '/basvuru-form');
            },
          ),
          ListTile(
            leading: Icon(Icons.list),
            title: Text('Başvuru Listele'),
            onTap: () {
              // Başvuru Listele sayfasına yönlendirme
              Navigator.pushReplacementNamed(context, '/basvuru-listele');
            },
          ),
        ],
      ),
    );
  }
}
