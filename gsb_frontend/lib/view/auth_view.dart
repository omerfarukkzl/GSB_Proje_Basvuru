import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_auth/auth_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_auth/auth_event.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_auth/auth_state.dart';

class AuthView extends StatelessWidget {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Login')),
      body: BlocListener<AuthBloc, AuthState>(
        listener: (context, state) {
          if (state is AuthAuthenticated) {
            Navigator.pushReplacementNamed(context, '/application');
          } else if (state is AuthError) {
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
                decoration: InputDecoration(labelText: 'Username'),
              ),
              TextField(
                controller: _passwordController,
                decoration: InputDecoration(labelText: 'Password'),
                obscureText: true,
              ),
              SizedBox(height: 20),
              ElevatedButton(
                onPressed: () {
                  final username = _usernameController.text;
                  final password = _passwordController.text;
                  context
                      .read<AuthBloc>()
                      .add(LoginRequested(username, password));
                },
                child: Text('Login'),
              ),
              TextButton(
                onPressed: () {
                  final username = _usernameController.text;
                  final password = _passwordController.text;
                  context
                      .read<AuthBloc>()
                      .add(RegisterRequested(username, password));
                },
                child: Text('Register'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
