import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_event.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_state.dart';

class UserEklePage extends StatefulWidget {
  @override
  _UserEklePageState createState() => _UserEklePageState();
}

class _UserEklePageState extends State<UserEklePage> {
  final _formKey = GlobalKey<FormState>();
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  int? _selectedRole;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Kullanıcı Ekle')),
      body: BlocListener<UserBloc, UserState>(
        listener: (context, state) {
          if (state is UserAdded) {
            ScaffoldMessenger.of(context).showSnackBar(
              SnackBar(content: Text('Kullanıcı başarıyla eklendi.')),
            );
            Navigator.pushNamed(context, '/userListele');
            _formKey.currentState!.reset();
          } else if (state is UserError) {
            ScaffoldMessenger.of(context).showSnackBar(
              SnackBar(content: Text(state.message)),
            );
          }
        },
        child: BlocBuilder<UserBloc, UserState>(
          builder: (context, state) {
            if (state is UserLoading) {
              return const Center(child: CircularProgressIndicator());
            } else {
              return Padding(
                padding: const EdgeInsets.all(16.0),
                child: Form(
                  key: _formKey,
                  child: ListView(
                    children: [
                      TextFormField(
                        controller: _usernameController,
                        decoration: InputDecoration(labelText: 'Kullanıcı Adı'),
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return 'Kullanıcı Adı gerekli';
                          }
                          return null;
                        },
                      ),
                      TextFormField(
                        controller: _passwordController,
                        decoration: InputDecoration(labelText: 'Şifre'),
                        obscureText: true,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return 'Şifre gerekli';
                          }
                          return null;
                        },
                      ),
                      DropdownButtonFormField<int>(
                        value: _selectedRole,
                        decoration:
                            const InputDecoration(labelText: 'Rol Seçin'),
                        items: const [
                          DropdownMenuItem(value: 1, child: Text('Admin')),
                          DropdownMenuItem(value: 2, child: Text('User')),
                        ],
                        onChanged: (value) {
                          setState(() {
                            _selectedRole = value;
                          });
                        },
                        validator: (value) {
                          if (value == null) {
                            return 'Rol seçimi gerekli';
                          }
                          return null;
                        },
                      ),
                      const SizedBox(height: 20),
                      ElevatedButton(
                        onPressed: () {
                          if (_formKey.currentState!.validate()) {
                            context.read<UserBloc>().add(
                                  AddUser(
                                    _usernameController.text,
                                    _passwordController.text,
                                    _selectedRole!,
                                  ),
                                );
                          }
                        },
                        child: const Text('Kullanıcı Ekle'),
                      ),
                    ],
                  ),
                ),
              );
            }
          },
        ),
      ),
    );
  }
}
