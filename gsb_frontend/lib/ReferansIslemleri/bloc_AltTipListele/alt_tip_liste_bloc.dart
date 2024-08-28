import 'package:bloc/bloc.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'alt_tip_liste_event.dart';
import 'alt_tip_liste_state.dart';

class AltTipListeBloc extends Bloc<AltTipListeEvent, AltTipListeState> {
  AltTipListeBloc() : super(AltTipListeInitial()) {
    on<FetchAltTipler>(
        _onFetchAltTipler); // FetchAltTipler event'ini işlemek için handler ekliyoruz
  }

  void _onFetchAltTipler(
      FetchAltTipler event, Emitter<AltTipListeState> emit) async {
    emit(AltTipListeLoading());
    try {
      final response =
          await http.get(Uri.parse('http://localhost:5232/api/AltTip'));
      if (response.statusCode == 200) {
        final List<dynamic> altTipler = json.decode(response.body);
        emit(AltTipListeLoaded(altTipler));
      } else {
        emit(AltTipListeError('AltTipleri yüklerken hata oluştu'));
      }
    } catch (e) {
      emit(AltTipListeError('Bağlantı hatası: $e'));
    }
  }
}
