import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application-list/application_list_bloc.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application/application_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_bloc.dart';
import 'package:gsb_frontend/home_page.dart';
import 'package:gsb_frontend/view/loginPages/login_page.dart';
import 'package:gsb_frontend/view/altTipPages/alt_tip_ekle_view.dart';
import 'package:gsb_frontend/view/altTipPages/alt_tip_liste_view.dart';
import 'package:gsb_frontend/view/applicationPages/application_list_view.dart';
import 'package:gsb_frontend/view/applicationPages/application_view.dart';
import 'package:gsb_frontend/view/loginPages/register_page.dart';
import 'package:gsb_frontend/view/userPages/userEkle_view.dart';
import 'package:gsb_frontend/view/userPages/userListele_view.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider<ApplicationListBloc>(
          create: (_) => ApplicationListBloc(),
        ),
        BlocProvider<ApplicationBloc>(create: (_) => ApplicationBloc()),
        BlocProvider<UserBloc>(create: (_) => UserBloc()),
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        title: 'Başvuru Sistemi',
        initialRoute: '/',
        routes: {
          '/': (context) => LoginPage(),
          '/register': (context) => RegisterPage(),
          '/home': (context) => HomePage(),
          '/application': (context) => ApplicationPage(),
          '/applicationList': (context) => const ApplicationListPage(),
          '/AltTipEkle': (context) => AltTipEklePage(),
          '/AltTipListele': (context) => AltTipListePage(),
          '/userEkle': (context) => UserEklePage(),
          '/userListele': (context) => UserListelePage(),
        },
      ),
    );
  }
}
