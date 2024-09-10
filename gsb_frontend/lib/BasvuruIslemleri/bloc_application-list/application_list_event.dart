import 'package:equatable/equatable.dart';

abstract class ApplicationListEvent extends Equatable {
  const ApplicationListEvent();

  @override
  List<Object> get props => [];
}

class LoadApplications extends ApplicationListEvent {}

class LoadFilteredApplications extends ApplicationListEvent {
  final Map<String, String> filterData;

  LoadFilteredApplications(this.filterData);

  @override
  List<Object> get props => [filterData];
}
