import 'package:flutter/material.dart';
import 'package:gsb_frontend/basvuru_form_view.dart';
import 'package:gsb_frontend/basvuru_listele_view.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'GSB Başvuru Sistemi',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      initialRoute: '/basvuru-form',
      routes: {
        '/basvuru-form': (context) => BasvuruForm(),
        '/basvuru-listele': (context) => BasvuruListelePage(),
      },
    );
  }
}
