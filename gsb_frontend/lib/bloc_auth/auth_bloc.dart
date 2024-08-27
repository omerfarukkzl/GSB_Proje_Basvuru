import 'package:flutter_bloc/flutter_bloc.dart';
import 'auth_event.dart';
import 'auth_state.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class AuthBloc extends Bloc<AuthEvent, AuthState> {
  AuthBloc() : super(AuthInitial()) {
    on<LoginRequested>(_onLoginRequested);
    on<RegisterRequested>(_onRegisterRequested);
    on<LogoutRequested>(_onLogoutRequested);
  }

  void _onLoginRequested(LoginRequested event, Emitter<AuthState> emit) async {
    emit(AuthLoading());

    try {
      final response = await http.post(
        Uri.parse('http://localhost:5232/api/Kullanici'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode(
            {'username': event.username, 'password': event.password}),
      );

      if (response.statusCode == 200) {
        emit(AuthAuthenticated());
      } else {
        emit(AuthError('Login failed'));
      }
    } catch (e) {
      emit(AuthError('An error occurred'));
    }
  }

  void _onRegisterRequested(
      RegisterRequested event, Emitter<AuthState> emit) async {
    emit(AuthLoading());

    try {
      final response = await http.post(
        Uri.parse('http://localhost:5000/api/Auth/Register'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode(
            {'username': event.username, 'password': event.password}),
      );

      if (response.statusCode == 201) {
        emit(AuthAuthenticated());
      } else {
        emit(AuthError('Registration failed'));
      }
    } catch (e) {
      emit(AuthError('An error occurred'));
    }
  }

  void _onLogoutRequested(LogoutRequested event, Emitter<AuthState> emit) {
    emit(AuthInitial());
  }
}
