import 'package:bloc/bloc.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'alt_tip_event.dart';
import 'alt_tip_state.dart';

class AltTipBloc extends Bloc<AltTipEvent, AltTipState> {
  AltTipBloc() : super(AltTipInitial()) {
    on<FetchTipler>(_onFetchTipler);
    on<AddAltTip>(_onAddAltTip);
  }

  void _onFetchTipler(FetchTipler event, Emitter<AltTipState> emit) async {
    emit(AltTipLoading());
    try {
      final response =
          await http.get(Uri.parse('http://localhost:5232/api/Tip'));
      if (response.statusCode == 200) {
        final List<dynamic> tipler = json.decode(response.body);
        emit(AltTipLoaded(tipler));
      } else {
        emit(AltTipError('Tipleri yüklerken hata oluştu'));
      }
    } catch (e) {
      emit(AltTipError('Bağlantı hatası: $e'));
    }
  }

  void _onAddAltTip(AddAltTip event, Emitter<AltTipState> emit) async {
    try {
      final response = await http.post(
        Uri.parse('http://localhost:5232/api/AltTip'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(<String, String>{
          'TipId': event.tipId,
          'Ad': event.altTipAd,
        }),
      );

      if (response.statusCode == 201) {
        emit(AltTipSuccess());
      } else {
        emit(AltTipError('AltTip eklerken hata oluştu'));
      }
    } catch (e) {
      emit(AltTipError('Bağlantı hatası: $e'));
    }
  }
}
