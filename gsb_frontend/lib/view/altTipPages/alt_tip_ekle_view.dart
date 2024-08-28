import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/ReferansIslemleri/bloc_AltTip/alt_tip_bloc.dart';
import 'package:gsb_frontend/ReferansIslemleri/bloc_AltTip/alt_tip_event.dart';
import 'package:gsb_frontend/ReferansIslemleri/bloc_AltTip/alt_tip_state.dart';

class AltTipEklePage extends StatelessWidget {
  final TextEditingController _altTipController = TextEditingController();
  String? selectedTipId;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('AltTip Ekle')),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: BlocProvider(
          create: (context) => AltTipBloc()..add(FetchTipler()),
          child: BlocBuilder<AltTipBloc, AltTipState>(
            builder: (context, state) {
              if (state is AltTipLoading) {
                return Center(child: CircularProgressIndicator());
              } else if (state is AltTipLoaded) {
                return Column(
                  children: [
                    DropdownButtonFormField<String>(
                      value: selectedTipId,
                      items: state.tipler.map<DropdownMenuItem<String>>((tip) {
                        return DropdownMenuItem<String>(
                          value: tip['id'].toString(),
                          child: Text(tip['ad']),
                        );
                      }).toList(),
                      onChanged: (value) {
                        selectedTipId =
                            value; // Tip seçildiğinde sadece değeri saklıyoruz
                      },
                      decoration: InputDecoration(labelText: 'Tip Seçiniz'),
                    ),
                    TextFormField(
                      controller: _altTipController,
                      decoration: InputDecoration(labelText: 'AltTip Giriniz'),
                    ),
                    SizedBox(height: 20),
                    ElevatedButton(
                      onPressed: () {
                        if (selectedTipId != null &&
                            _altTipController.text.isNotEmpty) {
                          context.read<AltTipBloc>().add(AddAltTip(
                                selectedTipId!,
                                _altTipController.text,
                              ));
                        } else {
                          ScaffoldMessenger.of(context).showSnackBar(
                            SnackBar(
                                content: Text(
                                    'Lütfen bir Tip seçin ve AltTip girin')),
                          );
                        }
                      },
                      child: Text('Yeni Kayıt Ekle'),
                    ),
                  ],
                );
              } else if (state is AltTipSuccess) {
                return Center(child: Text('AltTip başarıyla eklendi'));
              } else if (state is AltTipError) {
                return Center(child: Text(state.message));
              } else {
                return Center(child: Text('Tipler yüklenemedi.'));
              }
            },
          ),
        ),
      ),
    );
  }
}
