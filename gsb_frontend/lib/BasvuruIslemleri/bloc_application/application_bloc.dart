import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'application_event.dart';
import 'application_state.dart';

class ApplicationBloc extends Bloc<ApplicationEvent, ApplicationState> {
  ApplicationBloc() : super(ApplicationInitial()) {
    on<LoadDropdownData>(_onLoadDropdownData);
    on<SubmitApplication>(_onSubmitApplication);
  }

  void _onLoadDropdownData(
      LoadDropdownData event, Emitter<ApplicationState> emit) async {
    emit(ApplicationLoading());

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

        emit(ApplicationLoaded(organizedData));
      } else {
        emit(ApplicationError('Failed to load dropdown data'));
      }
    } catch (e) {
      emit(ApplicationError('Error: $e'));
    }
  }

  void _onSubmitApplication(
      SubmitApplication event, Emitter<ApplicationState> emit) async {
    emit(ApplicationLoading());

    try {
      final response = await http.post(
        Uri.parse('http://localhost:5232/api/Basvuru'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode(event.applicationData),
      );

      if (response.statusCode == 201 || response.statusCode == 200) {
        emit(ApplicationSubmitted());
      } else {
        emit(ApplicationError('Failed to submit application'));
      }
    } catch (e) {
      emit(ApplicationError('Error: $e.'));
      print(e);
    }
  }
}
