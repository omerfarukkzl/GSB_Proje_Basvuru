import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';

part 'user_ekle_event.dart';
part 'user_ekle_state.dart';

class UserEkleBloc extends Bloc<UserEkleEvent, UserEkleState> {
  UserEkleBloc() : super(UserEkleInitial()) {
    on<UserEkleEvent>((event, emit) {
      // TODO: implement event handler
    });
  }
}
