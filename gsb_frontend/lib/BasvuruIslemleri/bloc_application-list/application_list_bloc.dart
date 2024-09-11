import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application-list/application_list_event.dart';
import 'package:gsb_frontend/BasvuruIslemleri/bloc_application-list/application_list_state.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class ApplicationListBloc
    extends Bloc<ApplicationListEvent, ApplicationListState> {
  ApplicationListBloc() : super(ApplicationListInitial()) {
    on<LoadApplications>(_onLoadApplications);
    on<LoadFilterList>(_onLoadDropdownData);
  }
  void _onLoadDropdownData(
      LoadFilterList event, Emitter<ApplicationListState> emit) async {
    emit(ApplicationListLoading());
    print("LoadFilterList event triggered");

    try {
      final response = await http.get(
        Uri.parse('http://localhost:5232/api/AltTip'),
      );

      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);

        // Veriyi doğru bir şekilde organize ediyoruz
        final Map<String, List<dynamic>> organizedData = {
          'basvuranBirimler': data.where((item) => item['tipId'] == 1).toList(),
          'basvuruYapilanProje':
              data.where((item) => item['tipId'] == 2).toList(),
          'basvuruYapilanTur':
              data.where((item) => item['tipId'] == 3).toList(),
          'katilimciTurleri': data.where((item) => item['tipId'] == 4).toList(),
          'basvuruDonemleri': data.where((item) => item['tipId'] == 5).toList(),
          'basvuruDurumlari': data.where((item) => item['tipId'] == 6).toList(),
        };
        print("FilterListLoaded state will be emitted");

        emit(FilterListLoaded(organizedData));
      } else {
        emit(ApplicationListError('Failed to load dropdown data'));
      }
    } catch (e) {
      emit(ApplicationListError('Error: $e'));
    }
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
}
