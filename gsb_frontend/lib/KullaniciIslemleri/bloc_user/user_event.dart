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

class FetchUsers extends UserEvent {}
