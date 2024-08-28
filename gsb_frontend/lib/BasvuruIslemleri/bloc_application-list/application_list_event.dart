import 'package:equatable/equatable.dart';

abstract class ApplicationListEvent extends Equatable {
  const ApplicationListEvent();

  @override
  List<Object> get props => [];
}

class LoadApplications extends ApplicationListEvent {}