import 'package:equatable/equatable.dart';

abstract class AltTipState extends Equatable {
  @override
  List<Object> get props => [];
}

class AltTipInitial extends AltTipState {}

class AltTipLoading extends AltTipState {}

class AltTipLoaded extends AltTipState {
  final List<dynamic> tipler;

  AltTipLoaded(this.tipler);

  @override
  List<Object> get props => [tipler];
}

class AltTipSuccess extends AltTipState {}

class AltTipError extends AltTipState {
  final String message;

  AltTipError(this.message);

  @override
  List<Object> get props => [message];
}
