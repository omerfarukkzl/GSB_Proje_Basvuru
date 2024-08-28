import 'package:equatable/equatable.dart';

abstract class AltTipListeState extends Equatable {
  @override
  List<Object> get props => [];
}

class AltTipListeInitial extends AltTipListeState {}

class AltTipListeLoading extends AltTipListeState {}

class AltTipListeLoaded extends AltTipListeState {
  final List<dynamic> altTipler;

  AltTipListeLoaded(this.altTipler);

  @override
  List<Object> get props => [altTipler];
}

class AltTipListeError extends AltTipListeState {
  final String message;

  AltTipListeError(this.message);

  @override
  List<Object> get props => [message];
}
