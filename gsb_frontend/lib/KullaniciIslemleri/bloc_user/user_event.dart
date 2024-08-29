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

class MarkUserAsDeleted extends UserEvent {
  final int userId;
  final bool silinmeDurumu;

  MarkUserAsDeleted(this.userId, this.silinmeDurumu);

  @override
  List<Object> get props => [userId, silinmeDurumu];
}

class FetchUsers extends UserEvent {}
