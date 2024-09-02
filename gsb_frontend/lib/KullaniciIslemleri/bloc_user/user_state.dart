import 'package:equatable/equatable.dart';

abstract class UserState extends Equatable {
  const UserState();

  @override
  List<Object> get props => [];
}

class UserInitial extends UserState {}

class UserLoading extends UserState {}

class UserAdded extends UserState {}

class UserListLoaded extends UserState {
  final List<dynamic> users;

  UserListLoaded(this.users);

  @override
  List<Object> get props => [users];
}

class UserStatusUpdated extends UserState {}

class UserCreated extends UserState {}

class UserLoginLoading extends UserState {}

class UserLoginSuccess extends UserState {
  final String username;
  final String role;

  UserLoginSuccess(this.username, this.role);

  @override
  List<Object> get props => [username, role];
}

class UserLoginFailure extends UserState {
  final String message;

  UserLoginFailure(this.message);

  @override
  List<Object> get props => [message];
}

class UserError extends UserState {
  final String message;

  UserError(this.message);

  @override
  List<Object> get props => [message];
}
