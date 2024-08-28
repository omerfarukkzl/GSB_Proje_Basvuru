import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/ReferansIslemleri/bloc_AltTipListele/alt_tip_liste_bloc.dart';
import 'package:gsb_frontend/ReferansIslemleri/bloc_AltTipListele/alt_tip_liste_event.dart';
import 'package:gsb_frontend/ReferansIslemleri/bloc_AltTipListele/alt_tip_liste_state.dart';

class AltTipListePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('AltTip Listele')),
      body: BlocProvider(
        create: (context) => AltTipListeBloc()..add(FetchAltTipler()),
        child: BlocBuilder<AltTipListeBloc, AltTipListeState>(
          builder: (context, state) {
            if (state is AltTipListeLoading) {
              return Center(child: CircularProgressIndicator());
            } else if (state is AltTipListeLoaded) {
              return SingleChildScrollView(
                scrollDirection: Axis.vertical,
                child: DataTable(
                  columns: [
                    DataColumn(label: Text('AltTip Adı')),
                    DataColumn(label: Text('Tip Adı')),
                  ],
                  rows: state.altTipler.map<DataRow>((altTip) {
                    return DataRow(
                      cells: [
                        DataCell(
                          Text(altTip['ad'] ?? 'Proje Adı Yok'),
                        ),
                        DataCell(
                          Text(altTip['tipAd'] ?? 'Tür Adı Yok'),
                        ),
                      ],
                    );
                  }).toList(),
                ),
              );
            } else if (state is AltTipListeError) {
              return Center(child: Text(state.message));
            } else {
              return Center(child: Text('AltTipler yüklenemedi.'));
            }
          },
        ),
      ),
    );
  }
}
