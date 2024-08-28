import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application/application_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_auth/auth_bloc.dart';
import 'package:gsb_frontend/view/alt_tip_ekle_view.dart';
import 'package:gsb_frontend/view/alt_tip_liste_view.dart';
import 'package:gsb_frontend/view/application_list_view.dart';
import 'package:gsb_frontend/view/application_view.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider<AuthBloc>(create: (_) => AuthBloc()),
        BlocProvider<ApplicationBloc>(create: (_) => ApplicationBloc()),
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        title: 'Başvuru Sistemi',
        initialRoute: '/',
        routes: {
          '/': (context) => ApplicationListPage(),
          '/application': (context) => ApplicationPage(),
          '/applicationList': (context) => ApplicationListPage(),
          '/AltTipEkle': (context) => AltTipEklePage(),
          '/AltTipListele': (context) => AltTipListePage(),
        },
      ),
    );
  }
}
