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

  Future<Object> _pushUserListelePage(BuildContext context) async {
    await Future.delayed(const Duration(seconds: 1));
    return Navigator.pushNamed(context, '/userListele');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Kullanıcı Ekle'),
        centerTitle: true,
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(24.0),
          child: BlocListener<UserBloc, UserState>(
            listener: (context, state) {
              if (state is UserAdded) {
                ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(content: Text('Kullanıcı başarıyla eklendi.')),
                );
                _pushUserListelePage(context);
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
                  return Form(
                    key: _formKey,
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.stretch,
                      children: [
                        Center(
                          child: Column(
                            children: [
                              Icon(
                                Icons.person_add,
                                size: 100,
                                color: Colors.blueAccent,
                              ),
                              SizedBox(height: 20),
                              Text(
                                'Yeni Kullanıcı Ekle',
                                style: TextStyle(
                                  fontSize: 24,
                                  fontWeight: FontWeight.bold,
                                ),
                              ),
                            ],
                          ),
                        ),
                        SizedBox(height: 40),
                        TextFormField(
                          controller: _usernameController,
                          decoration: InputDecoration(
                            labelText: 'Kullanıcı Adı',
                            prefixIcon: Icon(Icons.person),
                            border: OutlineInputBorder(),
                          ),
                          validator: (value) {
                            if (value == null || value.isEmpty) {
                              return 'Kullanıcı Adı gerekli';
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
                              return 'Şifre gerekli';
                            }
                            return null;
                          },
                        ),
                        SizedBox(height: 20),
                        DropdownButtonFormField<int>(
                          value: _selectedRole,
                          decoration: const InputDecoration(
                            labelText: 'Rol Seçin',
                            border: OutlineInputBorder(),
                            prefixIcon: Icon(Icons.security),
                          ),
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
                        SizedBox(height: 30),
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
                          style: ElevatedButton.styleFrom(
                            padding: EdgeInsets.symmetric(vertical: 16.0),
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(8),
                            ),
                          ),
                          child: const Text(
                            'Kullanıcı Ekle',
                            style: TextStyle(fontSize: 18),
                          ),
                        ),
                      ],
                    ),
                  );
                }
              },
            ),
          ),
        ),
      ),
    );
  }
}
