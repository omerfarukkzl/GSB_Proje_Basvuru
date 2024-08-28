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
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  int _selectedRole = 1;

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => UserBloc(),
      child: Scaffold(
        appBar: AppBar(
          title: Text('Kullanıcı Ekle'),
        ),
        body: BlocListener<UserBloc, UserState>(
          listener: (context, state) {
            if (state is UserAdded) {
              ScaffoldMessenger.of(context).showSnackBar(
                SnackBar(content: Text('Kullanıcı başarıyla eklendi.')),
              );
            } else if (state is UserError) {
              ScaffoldMessenger.of(context).showSnackBar(
                SnackBar(content: Text(state.message)),
              );
            }
          },
          child: Padding(
            padding: const EdgeInsets.all(16.0),
            child: Column(
              children: [
                TextField(
                  controller: _usernameController,
                  decoration: InputDecoration(labelText: 'Kullanıcı Adı'),
                ),
                TextField(
                  controller: _passwordController,
                  decoration: InputDecoration(labelText: 'Şifre'),
                  obscureText: true,
                ),
                DropdownButton<int>(
                  value: _selectedRole,
                  onChanged: (value) {
                    setState(() {
                      _selectedRole = value!;
                    });
                  },
                  items: [
                    DropdownMenuItem(value: 1, child: Text('Admin')),
                    DropdownMenuItem(value: 2, child: Text('User')),
                  ],
                ),
                SizedBox(height: 20),
                ElevatedButton(
                  onPressed: () {
                    context.read<UserBloc>().add(
                          AddUser(
                            _usernameController.text,
                            _passwordController.text,
                            _selectedRole,
                          ),
                        );
                  },
                  child: Text('Kullanıcı Ekle'),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
