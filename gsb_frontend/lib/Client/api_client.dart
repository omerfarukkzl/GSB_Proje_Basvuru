import 'dart:convert';
import 'package:http/http.dart' as http;

class ApiClient {
  ApiClient();

  // Fetch users
  Future<List<dynamic>> fetchUsers() async {
    final response =
        await http.get(Uri.parse('http://localhost:5232/api/Kullanici'));
    if (response.statusCode == 200) {
      return jsonDecode(response.body);
    } else {
      throw Exception('Failed to load users');
    }
  }

  // Add user
  Future<void> addUser(String username, String password, int roleId) async {
    final response = await http.post(
      Uri.parse('http://localhost:5232/api/Kullanici'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({
        'KullaniciAdi': username,
        'Sifre': password,
        'RolId': roleId,
      }),
    );

    if (response.statusCode != 201) {
      throw Exception('Failed to add user');
    }
  }
}
