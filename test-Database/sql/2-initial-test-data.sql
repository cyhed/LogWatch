-- Переключение на базу данных
USE SURIMI_PROD;
GO

-- Вставка тестовых данных в таблицу AreaNumbers
INSERT INTO SURIMI_PROD.dbo.AreaNumbers (AREANUMBER,DESCRIPTION) VALUES
	 (N'0',N'Тестовая зона'),
	 (N'3101',N'Уч. Икра натуральная'),
	 (N'3102',N'Уч. Икра мойвы'),
	 (N'3103',N'Уч. Спреды'),
	 (N'3104',N'Уч. Сурими'),
	 (N'3105',N'Уч. Икра Осетровая'),
	 (N'3106',N'Уч. Икра Имитированная'),
	 (N'3201',N'Уч.икра нат ИМ40'),
	 (N'3204',N'Уч. сурими ИМ40'),
	 (N'3205',N'Уч.ИкраОсетрИМ40'),
	 (N'4208',N'Уч. р.конс. ИМ40');

-- Вставка тестовых данных в таблицу LogsStatusCodes
INSERT INTO SURIMI_PROD.dbo.LogsStatusCodes (STATUS,DESCRIPTION,Importance) VALUES
	 (N'0',N'Тестовая запись',0),
	 (N'1',N'Партия начата',0),
	 (N'10',N'Выбран оператор 2',0),
	 (N'11',N'Выбран оператор 3',0),
	 (N'13',N'Ошибка подключения к основному SQL серверу',1),
	 (N'14',N'Ошибка подключения к резервному SQL серверу',1),
	 (N'15',N'Ошибка загрузки агрегационного короба в SQL',1),
	 (N'16',N'Ошибка чтения рецепта из SQL',1),
	 (N'17',N'Ошибка загрузки статистики в SQL',1),
	 (N'18',N'Ошибка загрузки лога в SQL',1),
	 (N'19',N'Ошибка проверки короба на дублирование в SQL',1),
	 (N'2',N'Партия окончена',0),
	 (N'20',N'Ошибка проверки продукта на дублирование в SQL',1),
	 (N'21',N'Загруженный в БД короб не найден',0),
	 (N'22',N'При проверке выявлен дубль загружаемого короба',0),
	 (N'23',N'Несоответствие количества кодов в загружаемом коробе и БД',0),
	 (N'24',N'Загрузка короба в SQL происходит слишком долго',0),
	 (N'26',N'Ошибка подключения к камере продукта',1),
	 (N'27',N'Ошибка подключения к камере короба 1',1),
	 (N'28',N'Ошибка подключения к камере короба 2',1),
	 (N'29',N'Ошибка подключения к камере короба 3',1),
	 (N'3',N'Сработала отбраковка',0),
	 (N'35',N'Камера продукта не отвечает',1),
	 (N'36',N'Ошибка формата строки, отправленной с камеры продукта',1),
	 (N'37',N'Неверная позиция GS символа в коде, полученном с камеры продукта',1),
	 (N'38',N'EAN продукта не соответствует EAN коду рецепта',1),
	 (N'39',N'Код продукта уже существует в системе',1),
	 (N'4',N'Система находится в состоянии ошибки',0),
	 (N'40',N'Код продукта не был считан камерой',0),
	 (N'46',N'Камера короба у оператора не отвечает',1),
	 (N'47',N'Ошибка формата строки, отправленной с камеры короба',1),
	 (N'48',N'Неверная позиция GS символа в коде, полученном с камеры короба',1),
	 (N'49',N'EAN короба не соответствует EAN коду рецепта',0),
	 (N'5',N'Все ошибки устранены',0),
	 (N'50',N'Код короба уже существует в системе',0),
	 (N'56',N'Ошибка энкодера',1),
	 (N'57',N'Ошибка отбраковки',1),
	 (N'58',N'Слишком малое расстояние между продуктом',1),
	 (N'59',N'Затор на конвейере отбраковки',1),
	 (N'6',N'Нажата аварийная кнопка',0),
	 (N'60',N'Ошибка позиции лопатки отбраковки',1),
	 (N'61',N'Ошибка позиции лопатки на входе конвейера агрегации',1),
	 (N'62',N'Ошибка позиции распределительной лопатки 1',1),
	 (N'63',N'Ошибка позиции распределительной лопатки 2',1),
	 (N'66',N'Ошибка частотного преобразователя',1),
	 (N'67',N'Ошибка на датчике агрегации. Продукт пришел на датчик агрегации не сработав датчик аппликатора',1),
	 (N'68',N'Энкодер приближается к переполнению',1),
	 (N'69',N'Затор на датчике агрегации',1),
	 (N'7',N'Отжата аварийная кнопка',0),
	 (N'70',N'Лопатка переключена на позицию 0',0),
	 (N'71',N'Лопатка переключена на позицию 1',0),
	 (N'72',N'Лопатка переключена на позицию 2',0),
	 (N'73',N'Задача на переключение лопатки создана',0),
	 (N'77',N'Открыто окно секретных настроек',0),
	 (N'8',N'Нет активного оператора',0),
	 (N'9',N'Выбран оператор 1',0);

-- Вставка тестовых данных в таблицу Logs
INSERT INTO SURIMI_PROD.dbo.Logs (GUID,DATETIME,AREANUMBER,LINEID,STATUS) VALUES
	 (N'0000001D-4C38-47F4-B4C1-B25D01043D3C','2025-01-06 15:47:30.100',N'3104',N'4',N'10'),
	 (N'000003D8-C8AF-4B79-971F-B26100BE2A94','2025-01-10 11:32:22.390',N'3104',N'1',N'3'),
	 (N'000019F1-DAE2-4027-9878-B25E0085CEB4','2025-01-07 08:07:10.650',N'3104',N'1',N'70'),
	 (N'00003424-1413-46A7-BCC7-B260006D2015','2025-01-09 06:37:18.770',N'3104',N'7',N'72'),
	 (N'0000418D-E3B0-4E48-861A-B25E016B2F4C','2025-01-07 22:02:18.860',N'3104',N'2',N'3'),
	 (N'00004F74-4037-4DAC-B82A-B261016FD308','2025-01-10 22:19:12.360',N'3104',N'6',N'73'),
	 (N'00005515-114D-480C-B2E3-B260003B66F6','2025-01-09 03:36:16.510',N'3104',N'3',N'70'),
	 (N'000060CD-90CB-421F-A221-B25D012FC8BF','2025-01-06 18:26:02.550',N'3104',N'7',N'73'),
	 (N'0000638C-C274-46B3-AC0E-B25C008D1B54','2025-01-05 08:33:45.230',N'3104',N'6',N'9'),
	 (N'00006679-3DC6-42AB-B3E1-B25C015C62E8','2025-01-05 21:08:26.100',N'3104',N'7',N'71'),
	 (N'00006C11-FE4A-42B6-9035-B260005960C1','2025-01-09 05:25:24.850',N'3104',N'3',N'70'),
	 (N'00006F8B-EBC2-45F2-B0D4-B262005E28BE','2025-01-11 05:42:49.360',N'3104',N'3',N'3'),
	 (N'0000ACB7-C9E5-40AE-AF3E-B26100D5F9BE','2025-01-10 12:59:03.650',N'3104',N'4',N'8'),
	 (N'0000D0EE-0627-4B7F-A3D3-B261002F3199','2025-01-10 02:51:49.550',N'3104',N'7',N'73'),
	 (N'0000D417-E8A2-4BA5-929C-B25D01657EC5','2025-01-06 21:41:35.000',N'3104',N'7',N'70'),
	 (N'0000DD3A-9B23-489E-826F-B2600126F2FC','2025-01-09 17:53:52.600',N'3104',N'3',N'9'),
	 (N'0000E528-0BFD-400F-BF13-B25E006277C5','2025-01-07 05:58:30.620',N'3104',N'6',N'5'),
	 (N'0000EFC9-D5C9-4FB9-827F-B25C000E8979','2025-01-05 00:52:55.570',N'3104',N'5',N'73'),
	 (N'000103F2-6C25-4076-B9F5-B25D00D51701','2025-01-06 12:55:50.170',N'3104',N'3',N'40'),
	 (N'00010AF3-1A35-44D4-A778-B25C00858054','2025-01-05 08:06:03.780',N'3104',N'1',N'70'),
	 (N'00010F3A-6526-4452-BEA0-B25C0178C57A','2025-01-05 22:51:46.950',N'3104',N'7',N'11'),
	 (N'00012E63-98F9-4CD8-8F3C-B261008FA7C6','2025-01-10 08:43:01.960',N'3104',N'3',N'10'),
	 (N'00013034-83AB-405F-8576-B25D0137DB4A','2025-01-06 18:55:25.080',N'3104',N'3',N'40'),
	 (N'0001417B-4C8F-4EC3-B520-B260000579A3','2025-01-09 00:19:55.970',N'3104',N'7',N'73'),
	 (N'00017180-0DF8-49DF-A49F-B26100C007A4','2025-01-10 11:39:09.540',N'3104',N'6',N'67'),
	 (N'00017383-55F6-4DF7-B4C0-B25D00B64EA7','2025-01-06 11:03:45.560',N'3104',N'6',N'72'),
	 (N'000185DB-5EBF-4120-9C46-B26000DD3D1C','2025-01-09 13:25:30.240',N'3104',N'6',N'73'),
	 (N'00018DB0-0AE7-4903-8378-B26200FFF2D8','2025-01-11 15:31:52.800',N'3104',N'6',N'60'),
	 (N'00019CDC-E016-4E58-B08A-B25F00DB60D1','2025-01-08 13:18:43.860',N'3104',N'8',N'72'),
	 (N'0001A07E-62B3-4058-A1FD-B25E007E758C','2025-01-07 07:40:25.410',N'3104',N'8',N'40'),
	 (N'0001A08B-C2F4-4C72-842B-B25D009DB7C2','2025-01-06 09:34:13.960',N'3104',N'4',N'5'),
	 (N'0001A43B-4E42-4B42-A0A2-B25E003C8680','2025-01-07 03:40:21.900',N'3104',N'1',N'3'),
	 (N'0001A668-FF35-4920-83CA-B26000320787','2025-01-09 03:02:08.070',N'3104',N'3',N'9'),
	 (N'0001BA16-560B-4D73-89B4-B25D007E3146','2025-01-06 07:39:27.100',N'3104',N'5',N'71'),
	 (N'0001D27E-56F8-403F-A9BC-B25E00E18114','2025-01-07 13:41:02.130',N'3104',N'2',N'3'),
	 (N'000220A1-9624-438F-B27F-B26101729BFE','2025-01-10 22:29:20.740',N'3104',N'3',N'73'),
	 (N'00023446-793C-4AF2-AFB3-B26200CD89C9','2025-01-11 12:28:20.480',N'3104',N'7',N'10'),
	 (N'00023E02-48E4-493D-B42F-B25C0157FF5B','2025-01-05 20:52:27.370',N'3104',N'5',N'72'),
	 (N'000267A9-03D9-4D07-B833-B25F010000AE','2025-01-08 15:32:04.620',N'3104',N'7',N'9'),
	 (N'00026A90-E55C-481A-93DE-B25E002B4534','2025-01-07 02:37:32.520',N'3104',N'7',N'9'),
	 (N'00028702-D1AA-4985-8FA2-B25D0125ABAC','2025-01-06 17:49:13.260',N'3104',N'2',N'71'),
	 (N'00029759-0836-4988-A797-B25F0040476A','2025-01-08 03:54:01.890',N'3104',N'7',N'70'),
	 (N'0002A2F4-A10C-4BDA-9D7F-B25E001FC3EC','2025-01-07 01:55:39.180',N'3104',N'1',N'71'),
	 (N'0002A71F-4280-4E11-91E9-B25E013780B3','2025-01-07 18:54:08.790',N'3104',N'6',N'40'),
	 (N'0002BCF3-93CA-4DE1-ADC3-B2600133718D','2025-01-09 18:39:21.040',N'3104',N'7',N'9'),
	 (N'0002C185-15E2-475B-8F6C-B25F014928B5','2025-01-08 19:58:25.800',N'3104',N'7',N'73'),
	 (N'0002C5DC-762D-41E9-9A49-B25F00405E0D','2025-01-08 03:54:21.240',N'3104',N'6',N'72'),
	 (N'0002CDFE-3A99-42EC-8984-B26200569286','2025-01-11 05:15:11.000',N'3104',N'5',N'69'),
	 (N'0002F13C-05FF-4530-B7BA-B25D0137E760','2025-01-06 18:55:36.360',N'3104',N'1',N'72'),
	 (N'0002F4E0-E63A-49D6-9D7D-B25C008C7245','2025-01-05 08:31:20.910',N'3104',N'1',N'72'),
	 (N'0002F544-1BFA-4686-85AB-B25D011FFA0E','2025-01-06 17:28:29.470',N'3104',N'4',N'10'),
	 (N'0002F9E2-B0B4-4B4A-B116-B25E008BBCE7','2025-01-07 08:28:46.190',N'3104',N'6',N'40'),
	 (N'00030F37-F8A0-440B-AC81-B260003710DD','2025-01-09 03:20:29.300',N'3104',N'7',N'10'),
	 (N'000331B9-26A0-4F51-B13D-B25F014C773A','2025-01-08 20:10:28.170',N'3104',N'3',N'73'),
	 (N'0003326F-13F6-47DC-AAA3-B261002DEE9D','2025-01-10 02:47:13.000',N'3104',N'7',N'40'),
	 (N'00035ABB-B764-40C7-BA3A-B26100968643','2025-01-10 09:08:02.520',N'3104',N'6',N'11'),
	 (N'000362B7-55A7-4370-9743-B25E0053760D','2025-01-07 05:03:52.350',N'3104',N'1',N'71'),
	 (N'000369CC-5BA7-44E5-B4D7-B25C00B5D57C','2025-01-05 11:02:02.200',N'3104',N'5',N'71'),
	 (N'0003718F-073C-482B-BC6D-B26100B99035','2025-01-10 11:15:36.900',N'3104',N'5',N'9'),
	 (N'000377F1-8C7C-4F7F-859F-B25E0168A9F0','2025-01-07 21:53:08.190',N'3104',N'6',N'9'),
	 (N'00037924-A9AC-44EC-BCDC-B25D00C80525','2025-01-06 12:08:14.990',N'3104',N'6',N'3'),
	 (N'000380E8-479A-43C3-A006-B26100B5C1D2','2025-01-10 11:01:45.330',N'3104',N'6',N'3'),
	 (N'00038E86-0F14-4F33-885D-B25D0054BFD9','2025-01-06 05:08:33.770',N'3104',N'6',N'11'),
	 (N'0003B571-E6B1-45BA-9015-B25C016E57F8','2025-01-05 22:13:48.920',N'3104',N'8',N'3'),
	 (N'0003C54A-FD9D-4CE8-B234-B25D004AB607','2025-01-06 04:32:00.850',N'3104',N'5',N'11'),
	 (N'0003D73B-2A0E-4701-BD4A-B260012929E1','2025-01-09 18:01:56.350',N'3104',N'5',N'40'),
	 (N'0003F842-84BB-4285-A04A-B25F004E8319','2025-01-08 04:45:51.150',N'3104',N'6',N'73'),
	 (N'0003FE70-A65F-4518-817C-B260013ECC1A','2025-01-09 19:20:42.290',N'3104',N'7',N'70'),
	 (N'00041877-9F0E-4EBD-8B13-B25E00179A16','2025-01-07 01:25:55.890',N'3104',N'8',N'11'),
	 (N'00041CD5-A488-4088-82C1-B25D012EE358','2025-01-06 18:22:46.870',N'3104',N'4',N'70'),
	 (N'000436C9-D524-48C7-B0F5-B25F0168FAC4','2025-01-08 21:54:17.110',N'3104',N'3',N'3'),
	 (N'0004711E-4888-45A6-A333-B262010EAF34','2025-01-11 16:25:31.820',N'3104',N'7',N'73'),
	 (N'000472B3-03E2-4D06-BBDF-B25C00E9AC2E','2025-01-05 14:10:46.530',N'3104',N'3',N'10'),
	 (N'000476EB-6230-470A-B0E2-B260005462A3','2025-01-09 05:07:14.230',N'3104',N'3',N'3'),
	 (N'00048EFE-384C-40B9-9685-B2620067E3A7','2025-01-11 06:18:14.860',N'3104',N'1',N'3'),
	 (N'0004BDD5-25E2-42F0-AD1F-B25D015F1D00','2025-01-06 21:18:21.780',N'3104',N'1',N'73'),
	 (N'0004BFA9-7F80-4984-AF77-B25F015E443B','2025-01-08 21:15:16.510',N'3104',N'3',N'5'),
	 (N'0004D99E-E65A-4959-A9FF-B260007ABBA7','2025-01-09 07:26:51.420',N'3104',N'5',N'9'),
	 (N'0004EC8E-7ED4-4D53-B683-B25D0137640F','2025-01-06 18:53:44.350',N'3104',N'3',N'9'),
	 (N'0004F37B-0FE9-4B08-A6EC-B26000FDAB93','2025-01-09 15:23:34.970',N'3104',N'7',N'73'),
	 (N'000509B7-45C6-41EB-9B32-B25F01790288','2025-01-08 22:52:38.050',N'3104',N'7',N'72'),
	 (N'00051DD0-ADB2-4A9F-94B7-B25E0152D4F8','2025-01-07 20:33:38.930',N'3104',N'4',N'40'),
	 (N'0005338F-DDF4-4153-993D-B25C0018E620','2025-01-05 01:30:39.210',N'3104',N'7',N'70'),
	 (N'000564A4-90B2-4437-B43A-B26000230B17','2025-01-09 02:07:35.250',N'3104',N'8',N'3'),
	 (N'00056AB7-49E4-4C38-9F1A-B26200459E13','2025-01-11 04:13:28.150',N'3104',N'1',N'40'),
	 (N'00057002-22F7-4B7D-9C46-B25F015D9681','2025-01-08 21:12:48.200',N'3104',N'4',N'3'),
	 (N'00057BDF-5E82-4BB6-ACC8-B26000316AD0','2025-01-09 02:59:55.340',N'3104',N'4',N'10'),
	 (N'0005AC1E-E33E-4C89-9D40-B261006084DD','2025-01-10 05:51:24.800',N'3104',N'4',N'73'),
	 (N'0005AE3F-B04B-4A21-8600-B25D0029B524','2025-01-06 02:31:51.140',N'3104',N'6',N'40'),
	 (N'0005AF32-38EC-4870-B085-B25D014423AE','2025-01-06 19:40:09.260',N'3104',N'6',N'3'),
	 (N'0005C73F-EAE0-4259-9107-B2620048B144','2025-01-11 04:24:39.880',N'3104',N'3',N'40'),
	 (N'0005C750-051A-4951-A637-B260011FA83D','2025-01-09 17:27:19.640',N'3104',N'7',N'40'),
	 (N'0005D466-DD61-429C-9D29-B25E002997E1','2025-01-07 02:31:26.100',N'3104',N'8',N'73'),
	 (N'0005D53A-C8AF-42FF-8ED5-B25C00B9BDC4','2025-01-05 11:16:15.780',N'3104',N'1',N'10'),
	 (N'0005D804-2C77-4829-A450-B25F016E9984','2025-01-08 22:14:44.910',N'3104',N'6',N'9'),
	 (N'0005D991-A8E5-4B65-B7B9-B25E00A56B3A','2025-01-07 10:02:16.220',N'3104',N'6',N'3'),
	 (N'0005E1E5-5966-4176-8082-B26200C0C679','2025-01-11 11:41:52.330',N'3104',N'3',N'73'),
	 (N'0005E525-8CF6-4470-BECC-B25C00152825','2025-01-05 01:17:01.740',N'3104',N'7',N'70'),
	 (N'0005F8FA-B684-4FAC-B98E-B25F00EA9A5E','2025-01-08 14:14:09.790',N'3104',N'3',N'3'),
	 (N'00062EDE-1B27-40A8-BB00-B26000A13ECB','2025-01-09 09:47:04.530',N'3104',N'6',N'4');
