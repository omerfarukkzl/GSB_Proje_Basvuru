import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:gsb_frontend/Models/basvuru_model.dart';

class BasvuruService {
  final String baseUrl;

  BasvuruService(this.baseUrl);

  Future<void> submitBasvuru(Basvuru basvuru) async {
    final url = Uri.parse('$baseUrl/api/basvuru');

    final response = await http.post(
      url,
      headers: {
        'Content-Type': 'application/json',
      },
      body: jsonEncode(basvuru.toJson()),
    );

    if (response.statusCode != 201) {
      throw Exception('Başvuru kaydedilemedi: ${response.body}');
    }
  }
}
