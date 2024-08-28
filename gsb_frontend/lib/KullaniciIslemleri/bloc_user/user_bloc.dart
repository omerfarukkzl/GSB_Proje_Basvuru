import 'package:bloc/bloc.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'user_event.dart';
import 'user_state.dart';

class UserBloc extends Bloc<UserEvent, UserState> {
  UserBloc() : super(UserInitial()) {
    on<AddUser>(_onAddUser);
    on<FetchUsers>(_onFetchUsers);
  }

  void _onAddUser(AddUser event, Emitter<UserState> emit) async {
    print('AddUser olayı tetiklendi');

    emit(UserLoading());
    try {
      final response = await http.post(
        Uri.parse('http://localhost:5232/api/Kullanici'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(<String, dynamic>{
          'KullaniciAdi': event.username,
          'Sifre': event.password,
          'RolId': event.roleId,
        }),
      );

      if (response.statusCode == 201) {
        print('Kullanıcı eklendi');
        emit(UserAdded());
      } else {
        print('Kullanıcı eklenirken hata oluştu');
        emit(UserError('Kullanıcı eklerken hata oluştu.'));
      }
    } catch (e) {
      emit(UserError('Bağlantı hatası: $e'));
    }
  }

  void _onFetchUsers(FetchUsers event, Emitter<UserState> emit) async {
    emit(UserLoading());
    try {
      final response =
          await http.get(Uri.parse('http://localhost:5232/api/Kullanici'));

      if (response.statusCode == 200) {
        final List<dynamic> users = json.decode(response.body);
        emit(UserListLoaded(users));
      } else {
        emit(UserError('Kullanıcıları yüklerken hata oluştu.'));
      }
    } catch (e) {
      emit(UserError('Bağlantı hatası: $e'));
    }
  }
}
