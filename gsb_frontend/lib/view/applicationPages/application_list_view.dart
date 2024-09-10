import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application-list/application_list_bloc.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application-list/application_list_event.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application-list/application_list_state.dart';

class ApplicationListPage extends StatelessWidget {
  const ApplicationListPage({super.key});

  @override
  Widget build(BuildContext context) {
    final TextEditingController _projeAdiController = TextEditingController();
    final TextEditingController _basvuranBirimIdController =
        TextEditingController();
    // Diğer filtreleme alanları için controller'lar ekleyin

    return Scaffold(
      appBar: AppBar(
        title: Text('Başvuru Listesi'),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.restorablePushReplacementNamed(context, '/application');
        },
        child: Icon(Icons.add),
      ),
      body: BlocProvider(
        create: (_) => ApplicationListBloc()..add(LoadApplications()),
        child: BlocBuilder<ApplicationListBloc, ApplicationListState>(
          builder: (context, state) {
            if (state is ApplicationListLoading) {
              return Center(child: CircularProgressIndicator());
            } else if (state is ApplicationListLoaded) {
              return Column(
                children: [
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: Column(
                      children: [
                        TextField(
                          controller: _projeAdiController,
                          decoration: InputDecoration(labelText: 'Proje Adı'),
                        ),
                        TextField(
                          controller: _basvuranBirimIdController,
                          decoration:
                              InputDecoration(labelText: 'Başvuran Birim ID'),
                        ),
                        // Diğer filtreleme alanları için TextField'lar ekleyin
                        ElevatedButton(
                          onPressed: () {
                            final filterData = {
                              'ProjeAdi': _projeAdiController.text,
                              'BasvuranBirimId':
                                  _basvuranBirimIdController.text,
                              // Diğer filtreleme alanlarını ekleyin
                            };
                            context
                                .read<ApplicationListBloc>()
                                .add(LoadFilteredApplications(filterData));
                          },
                          child: Text('Filtrele'),
                        ),
                      ],
                    ),
                  ),
                  Expanded(
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
                              DataCell(Text(
                                  application['projeAdi'] ?? 'Proje Adı Yok')),
                              DataCell(Text(application['basvuranBirimAdi'] ??
                                  'Birim Adı Yok')),
                              DataCell(Text(
                                  application['basvuruYapilanProjeAdi'] ??
                                      'Proje Adı Yok')),
                              DataCell(Text(
                                  application['basvuruYapilanTurAdi'] ??
                                      'Tür Adı Yok')),
                              DataCell(Text(application['katilimciTurAdi'] ??
                                  'Katılımcı Türü Yok')),
                              DataCell(Text(application['basvuruDonemAdi'] ??
                                  'Dönem Adı Yok')),
                              DataCell(Text(application['basvuruTarihi']
                                      ?.split('T')
                                      .first ??
                                  'Tarih Yok')),
                              DataCell(Text(application['basvuruDurumAdi'] ??
                                  'Durum Adı Yok')),
                            ],
                          );
                        }).toList(),
                      ),
                    ),
                  ),
                ],
              );
            } else if (state is ApplicationListError) {
              return Center(child: Text(state.message));
            } else {
              return Center(child: Text('Başvurular yüklenemedi.'));
            }
          },
        ),
      ),
    );
  }
}
