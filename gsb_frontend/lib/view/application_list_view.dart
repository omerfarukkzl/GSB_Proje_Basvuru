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
      drawer: Drawer(
        child: ListView(
          children: [
            Material(
              color: Colors.blueAccent,
              child: InkWell(
                onTap: () {
                  /// Close Navigation drawer before
                  Navigator.pop(context);
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => ApplicationListPage()),
                  );
                },
                child: Container(
                  padding: EdgeInsets.only(
                      top: MediaQuery.of(context).padding.top, bottom: 24),
                  child: const Column(
                    children: [
                      CircleAvatar(
                        radius: 52,
                        backgroundImage: AssetImage('assets/gsb_logo.png'),
                      ),
                      SizedBox(
                        height: 12,
                      ),
                      FittedBox(
                        child: Text(
                          'Gençlik ve Spor Bakanlığı \n       Başvuru Yönetimi',
                          style: TextStyle(fontSize: 28, color: Colors.white),
                        ),
                      ),
                      Text(
                        '@gsb.gov.tr',
                        style: TextStyle(fontSize: 14, color: Colors.white),
                      ),
                    ],
                  ),
                ),
              ),
            ),
            ExpansionTile(
              title: Text('Başvuru İşlemleri'),
              children: [
                ListTile(
                  title: Text('Başvuru Yap'),
                  onTap: () {
                    Navigator.pushNamed(context, '/application');
                  },
                ),
                ListTile(
                  title: Text('Başvuru Listele'),
                  onTap: () {
                    Navigator.pushNamed(context, '/applicationList');
                  },
                ),
              ],
            ),
            ExpansionTile(
              title: Text('Referans İşlemleri'),
              children: [
                ListTile(
                  title: Text('AltTip Ekle'),
                  onTap: () {
                    Navigator.pushNamed(context, '/AltTipEkle');
                  },
                ),
                ListTile(
                  title: Text('AltTip Listele'),
                  onTap: () {
                    Navigator.pushNamed(context, '/AltTipListele');
                  },
                )
              ],
            )
          ],
        ),
      ),
      body: BlocProvider(
        create: (_) => ApplicationListBloc()..add(LoadApplications()),
        child: BlocBuilder<ApplicationListBloc, ApplicationListState>(
          builder: (context, state) {
            if (state is ApplicationListLoading) {
              return Center(child: CircularProgressIndicator());
            } else if (state is ApplicationListLoaded) {
              return SingleChildScrollView(
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
