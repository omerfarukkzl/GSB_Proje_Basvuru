import 'package:bloc/bloc.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'user_event.dart';
import 'user_state.dart';

class UserBloc extends Bloc<UserEvent, UserState> {
  UserBloc() : super(UserInitial()) {
    on<FetchUsers>(_onFetchUsers);
    on<AddUser>(_onAddUser);
    on<UpdateUserStatus>(_onUpdateUserStatus);
    on<MarkUserAsDeleted>(_onMarkUserAsDeleted);
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

  void _onAddUser(AddUser event, Emitter<UserState> emit) async {
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
        emit(UserAdded());
        add(FetchUsers()); // Refresh the list after adding a user
      } else {
        emit(UserError('Kullanıcı eklerken hata oluştu.'));
      }
    } catch (e) {
      emit(UserError('Bağlantı hatası: $e'));
    }
  }

  void _onUpdateUserStatus(
      UpdateUserStatus event, Emitter<UserState> emit) async {
    emit(UserLoading());
    try {
      final response = await http.put(
        Uri.parse('http://localhost:5232/api/Kullanici/${event.userId}'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(<String, dynamic>{
          'AktiflikDurumu': event.aktiflikDurumu,
        }),
      );

      if (response.statusCode == 200) {
        emit(UserStatusUpdated());
        add(FetchUsers()); // Refresh the list after updating the user status
      } else {
        emit(UserError('Kullanıcı durumunu güncellerken hata oluştu.'));
      }
    } catch (e) {
      emit(UserError('Bağlantı hatası: $e'));
    }
  }

  void _onMarkUserAsDeleted(
      MarkUserAsDeleted event, Emitter<UserState> emit) async {
    emit(UserLoading());
    try {
      final response = await http.put(
        Uri.parse('http://localhost:5232/api/Kullanici/${event.userId}'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(<String, dynamic>{
          'SilinmeDurumu': true,
        }),
      );

      if (response.statusCode == 200) {
        emit(UserStatusUpdated());
        add(FetchUsers()); // Refresh the list after marking as deleted
      } else {
        emit(
            UserError('Kullanıcı silinmiş olarak işaretlenirken hata oluştu.'));
      }
    } catch (e) {
      emit(UserError('Bağlantı hatası: $e'));
    }
  }
}
