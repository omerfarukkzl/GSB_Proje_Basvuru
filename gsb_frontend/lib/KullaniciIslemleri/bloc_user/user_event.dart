import 'package:equatable/equatable.dart';

abstract class UserEvent extends Equatable {
  const UserEvent();

  @override
  List<Object> get props => [];
}

class AddUser extends UserEvent {
  final String username;
  final String password;
  final int roleId;

  AddUser(this.username, this.password, this.roleId);

  @override
  List<Object> get props => [username, password, roleId];
}

class UpdateUserStatus extends UserEvent {
  final int userId;
  final bool aktiflikDurumu;

  UpdateUserStatus(
    this.userId,
    this.aktiflikDurumu,
  );

  @override
  List<Object> get props => [
        userId,
        aktiflikDurumu,
      ];
}

class LoginUser extends UserEvent {
  final String username;
  final String password;

  LoginUser(this.username, this.password);

  @override
  List<Object> get props => [username, password];
}

class CreateUser extends UserEvent {
  final String username;
  final String password;
  final int roleId;
  final bool aktiflikDurumu;
  final bool silinmeDurumu;
  CreateUser(this.username, this.password,
      {this.roleId = 2,
      this.aktiflikDurumu = false,
      this.silinmeDurumu = false});
}

class MarkUserAsDeleted extends UserEvent {
  final int userId;
  final bool silinmeDurumu;

  MarkUserAsDeleted(this.userId, this.silinmeDurumu);

  @override
  List<Object> get props => [userId, silinmeDurumu];
}

class FetchUsers extends UserEvent {}
