import 'package:equatable/equatable.dart';

abstract class ApplicationListState extends Equatable {
  const ApplicationListState();

  @override
  List<Object> get props => [];
}

class ApplicationListInitial extends ApplicationListState {}

class ApplicationListLoading extends ApplicationListState {}

class ApplicationListLoaded extends ApplicationListState {
  final List<dynamic> applications;

  const ApplicationListLoaded(this.applications);

  @override
  List<Object> get props => [applications];
}

class ApplicationListError extends ApplicationListState {
  final String message;

  const ApplicationListError(this.message);

  @override
  List<Object> get props => [message];
}