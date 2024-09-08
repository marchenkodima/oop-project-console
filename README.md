# ����� ³�������� ���������� ��� ��������

## ���� ��������� ������

1.	User � ���������� (������� ����); �� ��� ���������� name (��� �����������), id (���������� �������������), username (��������� ��� �����������), password (������ �����������). ���� �������������� (������ ����� signIn). �������� � ���� ��������������� ���������� (��������� �������).
2.	Student � �������, �������� ������� Group (��������� ������� � ����). � �������������� �������� User (�������� �� ����� User); �� ��� ����������: id (������������� ��������), groupID (������������� �����), chatIDs (������ �������������� ��������� ����). ���� ��������� ��� �������� (����� contactSupport). �������� � �������� ������������, ���.
3.	Administrator � ������������. � �������������� �������� User (�������� �� ����� User); �� ��� ����������: chatIDs (������ �������������� ��������� ����). ���� �������� �� ������� ����� ����������� (addStudent), �������� ����������� (deleteStudent), �������� ������ �������� (getStudents), �������� ������ ������������� (getAdministrators), ������ �� ������� ���� ����� (addGroup). �������� � �������� ������� � ���.
4.	SupportChat � ��� ��� �����������. �� ��� ����������: id (������������� ����), studentID (������������� ��������), administratorID (������������� �������������). ���� ����������������� ��� �������� ����������� (sendMessage), ��������� ����������� (deleteMessage), ��������� ������ ���������� (getMessages). �������� � �������� �������, ������������ � �����������.
5.	ChatMessage � �����������, �������� ������� ������� SupportChat (��������� ������� - ����).  �� ��� ����������: senderID (������������� ����������), timestamp (���� �������� �����������), message (����� �����������), id (������������� �����������), chatId (������������� ����, �� ����� ��������).
6.	Group � ����� ��������. �� ��� ����������: studentIDs (������ �������������� �������� �� � �������� �����). ���� ����������������� ��� ��������� �������� �� ����� (attachStudent) � ��������� �������� � ����� (detachStudent), ��������� ������ �������� � ���� (getStudents).

## ĳ������ �����

![��������� �� ���������� �������� ��������� ������ �� ������ �� ����](class_diagram.drawio.png)

![�������� ����������� �������� ����� ��������� ������](class_diagram_detailed.drawio.png)