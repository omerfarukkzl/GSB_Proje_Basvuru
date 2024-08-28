import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_event.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_state.dart';

class UserListelePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Kullanıcıları Listele')),
      body: BlocProvider(
        create: (_) => UserBloc()..add(FetchUsers()),
        child: BlocBuilder<UserBloc, UserState>(
          builder: (context, state) {
            if (state is UserLoading) {
              return Center(child: CircularProgressIndicator());
            } else if (state is UserListLoaded) {
              return SingleChildScrollView(
                scrollDirection: Axis.vertical,
                child: DataTable(
                  columns: const [
                    DataColumn(
                      label: Text('Kullanıcı Adı'),
                    ),
                    DataColumn(label: Text('Şifre')),
                    DataColumn(label: Text('Rol Adı')),
                  ],
                  rows: state.users.map<DataRow>((users) {
                    return DataRow(
                      cells: [
                        DataCell(
                          Text(
                            users['kullaniciAdi'],
                          ),
                        ),
                        DataCell(
                          Text(
                            users['sifre'],
                          ),
                        ),
                        DataCell(Text(
                          users['rolAdi'],
                        )),
                      ],
                    );
                  }).toList(),
                ),
              );
            } else if (state is UserError) {
              return Center(child: Text(state.message));
            } else {
              return Center(child: Text('Kullanıcılar yüklenemedi.'));
            }
          },
        ),
      ),
    );
  }
}
