import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application-list/application_list_event.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application-list/application_list_state.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class ApplicationListBloc
    extends Bloc<ApplicationListEvent, ApplicationListState> {
  ApplicationListBloc() : super(ApplicationListInitial()) {
    on<LoadApplications>(_onLoadApplications);
    on<LoadFilteredApplications>(_onLoadFilteredApplications);
  }

  void _onLoadApplications(
      LoadApplications event, Emitter<ApplicationListState> emit) async {
    emit(ApplicationListLoading());

    try {
      final response = await http.get(
        Uri.parse('http://localhost:5232/api/Basvuru/'),
      );

      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        emit(ApplicationListLoaded(data));
      } else {
        emit(ApplicationListError('Failed to load applications'));
      }
    } catch (e) {
      emit(ApplicationListError('Error: $e'));
    }
  }

  void _onLoadFilteredApplications(LoadFilteredApplications event,
      Emitter<ApplicationListState> emit) async {
    emit(ApplicationListLoading());

    try {
      final response = await http.get(
        Uri.parse(
            'http://localhost:5232/api/Basvuru?${Uri(queryParameters: event.filterData).query}'),
      );

      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        emit(ApplicationListLoaded(data));
      } else {
        emit(ApplicationListError('Failed to load filtered applications'));
      }
    } catch (e) {
      emit(ApplicationListError('Error: $e'));
    }
  }
}
