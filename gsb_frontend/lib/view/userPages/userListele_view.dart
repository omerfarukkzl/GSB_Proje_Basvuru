import 'package:flutter/cupertino.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_bloc.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_event.dart';
import 'package:gsb_frontend/KullaniciIslemleri/bloc_user/user_state.dart';

class UserListelePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return CupertinoPageScaffold(
      navigationBar: CupertinoNavigationBar(
        middle: Text('Kullanıcıları Listele'),
      ),
      child: BlocProvider(
        create: (_) => UserBloc()..add(FetchUsers()),
        child: BlocBuilder<UserBloc, UserState>(
          builder: (context, state) {
            if (state is UserLoading) {
              return Center(child: CupertinoActivityIndicator());
            } else if (state is UserListLoaded) {
              return ListView.builder(
                itemCount: state.users.length,
                itemBuilder: (context, index) {
                  final user = state.users[index];
                  return Dismissible(
                    key: Key(
                      user['id'].toString(),
                    ),
                    direction: DismissDirection.endToStart,
                    confirmDismiss: (direction) async {
                      final confirm = await _showDeleteConfirmation(
                          context,
                          user['id'],
                          user['kullaniciAdi'],
                          user['silinmeDurumu']);
                      if (confirm != null && confirm) {
                        context.read<UserBloc>().add(MarkUserAsDeleted(
                            user['id'], user['silinmeDurumu']));
                        return true;
                      }
                    },
                    background: Container(
                      color: CupertinoColors.destructiveRed,
                      alignment: Alignment.centerRight,
                      padding: EdgeInsets.symmetric(horizontal: 20),
                      child: Icon(CupertinoIcons.delete,
                          color: CupertinoColors.white),
                    ),
                    child: CupertinoListTile(
                      title: Text(user['kullaniciAdi']),
                      subtitle: Text('Rol: ${user['rolAdi']}'),
                      trailing: CupertinoSwitch(
                        value: user['aktiflikDurumu'],
                        onChanged: (bool value) {
                          context.read<UserBloc>().add(
                                UpdateUserStatus(
                                  user['id'],
                                  value,
                                ),
                              );
                        },
                      ),
                    ),
                  );
                },
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

  Future<bool?> _showDeleteConfirmation(BuildContext context, int userId,
      String kullaniciAdi, bool silinmeDurumu) {
    return showCupertinoModalPopup<bool>(
      context: context,
      builder: (BuildContext context) => CupertinoActionSheet(
        title: Text('Kullanıcıyı silmek istediğinize emin misiniz?'),
        message: Text('$kullaniciAdi silinmiş olarak işaretlenecek.'),
        actions: <CupertinoActionSheetAction>[
          CupertinoActionSheetAction(
            isDestructiveAction: true,
            onPressed: () {
              context
                  .read<UserBloc>()
                  .add(MarkUserAsDeleted(userId, silinmeDurumu));
              Navigator.pop(context, true);
              _showSuccessDialog(
                  context, '$kullaniciAdi silinmiş olarak işaretlendi');
            },
            child: const Text('Sil'),
          ),
          CupertinoActionSheetAction(
            onPressed: () {
              Navigator.pop(context, false);
            },
            child: const Text('İptal'),
          ),
        ],
      ),
    );
  }

  void _showSuccessDialog(BuildContext context, String message) {
    showCupertinoDialog(
      context: context,
      builder: (BuildContext context) {
        return CupertinoAlertDialog(
          title: Text('Başarılı'),
          content: Text(message),
          actions: [
            CupertinoDialogAction(
              child: Text('Tamam'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }
}
