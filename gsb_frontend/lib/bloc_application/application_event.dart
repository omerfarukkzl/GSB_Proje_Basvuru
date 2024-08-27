import 'package:equatable/equatable.dart';

abstract class ApplicationEvent extends Equatable {
  const ApplicationEvent();

  @override
  List<Object> get props => [];
}

class LoadDropdownData extends ApplicationEvent {}

class SubmitApplication extends ApplicationEvent {
  final Map<String, dynamic> applicationData;

  const SubmitApplication(this.applicationData);

  @override
  List<Object> get props => [applicationData];
}
