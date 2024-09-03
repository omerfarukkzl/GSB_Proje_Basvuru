import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_event.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_state.dart';

class RegisterPage extends StatefulWidget {
  const RegisterPage({super.key});

  @override
  RegisterPageState createState() => RegisterPageState();
}

class RegisterPageState extends State<RegisterPage> {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  void _register() {
    if (_formKey.currentState!.validate()) {
      context.read<UserBloc>().add(
            CreateUser(_usernameController.text, _passwordController.text),
          );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Kayıt Ol'),
        centerTitle: true, // Başlığı ortala
      ),
      body: SingleChildScrollView(
        // Scroll ekle, küçük ekranlarda taşmalar olmasın
        child: Padding(
          padding: const EdgeInsets.all(24.0),
          child: Form(
            key: _formKey,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment:
                  CrossAxisAlignment.stretch, // Elemanları genişlet
              children: [
                // Üstte bir simge ve hoşgeldiniz mesajı ekleyin
                Center(
                  child: Column(
                    children: [
                      Icon(
                        Icons.person_add,
                        size: 100,
                        color: Colors.greenAccent,
                      ),
                      SizedBox(height: 20),
                      Text(
                        'Yeni Hesap Oluşturun!',
                        style: TextStyle(
                          fontSize: 24,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ],
                  ),
                ),
                SizedBox(height: 40),
                // Kullanıcı adı ve şifre giriş alanları
                TextFormField(
                  controller: _usernameController,
                  decoration: InputDecoration(
                    labelText: 'Kullanıcı Adı',
                    prefixIcon: Icon(Icons.person),
                    border: OutlineInputBorder(),
                  ),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Kullanıcı adı boş olamaz';
                    }
                    return null;
                  },
                ),
                SizedBox(height: 20),
                TextFormField(
                  controller: _passwordController,
                  decoration: InputDecoration(
                    labelText: 'Şifre',
                    prefixIcon: Icon(Icons.lock),
                    border: OutlineInputBorder(),
                  ),
                  obscureText: true,
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Şifre boş olamaz';
                    }
                    return null;
                  },
                ),
                SizedBox(height: 30),
                // Kayıt ol butonu
                ElevatedButton(
                  onPressed: _register,
                  style: ElevatedButton.styleFrom(
                    padding: EdgeInsets.symmetric(vertical: 16.0),
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(8),
                    ),
                  ),
                  child: Text(
                    'Kayıt Ol',
                    style: TextStyle(fontSize: 18),
                  ),
                ),
                SizedBox(height: 10),
                BlocListener<UserBloc, UserState>(
                  listener: (context, state) {
                    if (state is UserCreated) {
                      ScaffoldMessenger.of(context).showSnackBar(
                        SnackBar(content: Text('Kayıt başarılı!')),
                      );
                      Navigator.pushNamed(context, '/');
                    } else if (state is UserError) {
                      ScaffoldMessenger.of(context).showSnackBar(
                        SnackBar(content: Text(state.message)),
                      );
                    }
                  },
                  child: Container(),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
