import 'package:equatable/equatable.dart';

abstract class ApplicationListEvent extends Equatable {
  const ApplicationListEvent();

  @override
  List<Object> get props => [];
}

class LoadFilterList extends ApplicationListEvent {}

class LoadApplications extends ApplicationListEvent {
  final Map<String, String?> queryParameters;

  LoadApplications([this.queryParameters = const {}]);

  @override
  List<Object> get props => [queryParameters];
}
