import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/Bloc/BasvuruBloc/basvuru_Event.dart';
import 'package:gsb_frontend/Bloc/BasvuruBloc/basvuru_State.dart';
import 'package:gsb_frontend/Bloc/BasvuruBloc/basvuru_service.dart';

class BasvuruBloc extends Bloc<BasvuruEvent, BasvuruState> {
  final BasvuruService basvuruService;

  BasvuruBloc(this.basvuruService) : super(BasvuruInitial()) {
    on<LoadComboBoxData>(_onLoadComboBoxData);
    on<SubmitBasvuru>(_onSubmitBasvuru);
  }

  void _onLoadComboBoxData(LoadComboBoxData event, Emitter<BasvuruState> emit) {
    // Verileri yüklemek için işlemler (simüle edilmiş)
    emit(ComboBoxDataLoaded(
      basvuruProjeList: ["Proje1", "Proje2"],
      basvuruTurList: ["Tur1", "Tur2"],
      basvuranBirimList: ["Birim1", "Birim2"],
      katilimciTuruList: ["Turu1", "Turu2"],
      basvuruDonemiList: ["R1", "R2", "R3"],
    ));
  }

  void _onSubmitBasvuru(SubmitBasvuru event, Emitter<BasvuruState> emit) async {
    emit(BasvuruLoading());

    try {
      await basvuruService.submitBasvuru(event.basvuru);
      emit(BasvuruSuccess());
    } catch (error) {
      emit(BasvuruFailure());
    }
  }
}
