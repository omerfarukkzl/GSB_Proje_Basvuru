import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_event.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_state.dart';

class LoginPage extends StatefulWidget {
  @override
  LoginPageState createState() => LoginPageState();
}

class LoginPageState extends State<LoginPage> {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Giriş Yap'),
        centerTitle: true, // Başlığı ortala
      ),
      body: SingleChildScrollView(
        // Scroll ekle, küçük ekranlarda taşmalar olmasın
        child: Padding(
          padding: const EdgeInsets.all(24.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment:
                CrossAxisAlignment.stretch, // Elemanları genişlet
            children: [
              // Giriş sayfasına bir logo veya başlık ekleyin
              Center(
                child: Column(
                  children: [
                    Icon(
                      Icons.account_circle,
                      size: 100,
                      color: Colors.blueAccent,
                    ),
                    SizedBox(height: 20),
                    Text(
                      'Hoşgeldiniz!',
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
              TextField(
                controller: _usernameController,
                decoration: InputDecoration(
                  labelText: 'Kullanıcı Adı',
                  prefixIcon: Icon(Icons.person),
                  border: OutlineInputBorder(), // Çerçeve ekle
                ),
              ),
              SizedBox(height: 20),
              TextField(
                controller: _passwordController,
                decoration: InputDecoration(
                  labelText: 'Şifre',
                  prefixIcon: Icon(Icons.lock),
                  border: OutlineInputBorder(),
                ),
                obscureText: true,
              ),
              SizedBox(height: 30),
              // Giriş yap butonu
              ElevatedButton(
                onPressed: () {
                  context.read<UserBloc>().add(
                        LoginUser(
                          _usernameController.text,
                          _passwordController.text,
                        ),
                      );
                },
                style: ElevatedButton.styleFrom(
                  padding: EdgeInsets.symmetric(vertical: 16.0),
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(8),
                  ),
                ),
                child: Text(
                  'Giriş Yap',
                  style: TextStyle(fontSize: 18),
                ),
              ),
              SizedBox(height: 10),
              // Kayıt ol butonu
              Center(
                child: TextButton(
                  onPressed: () {
                    Navigator.pushNamed(context, '/register');
                  },
                  child: const Text(
                    'Kayıt Ol',
                    style: TextStyle(
                      decoration: TextDecoration.underline,
                      color: Colors.blueAccent,
                    ),
                  ),
                ),
              ),
              BlocConsumer<UserBloc, UserState>(
                listener: (context, state) {
                  if (state is UserLoginSuccess) {
                    ScaffoldMessenger.of(context).showSnackBar(
                      SnackBar(content: Text('Giriş başarılı!')),
                    );
                    Navigator.pushReplacementNamed(context, '/home');
                  } else if (state is UserLoginFailure) {
                    ScaffoldMessenger.of(context).showSnackBar(
                      SnackBar(content: Text(state.message)),
                    );
                  }
                },
                builder: (context, state) {
                  if (state is UserLoginLoading) {
                    return Center(
                      child: CircularProgressIndicator(),
                    );
                  }
                  return Container();
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}
