import 'package:equatable/equatable.dart';

abstract class ApplicationState extends Equatable {
  const ApplicationState();

  @override
  List<Object> get props => [];
}

class ApplicationInitial extends ApplicationState {}

class ApplicationLoading extends ApplicationState {}

class ApplicationLoaded extends ApplicationState {
  final Map<String, dynamic> dropdownData;

  const ApplicationLoaded(this.dropdownData);

  @override
  List<Object> get props => [dropdownData];
}

class ApplicationSubmitted extends ApplicationState {}

class ApplicationError extends ApplicationState {
  final String message;

  const ApplicationError(this.message);

  @override
  List<Object> get props => [message];
}
