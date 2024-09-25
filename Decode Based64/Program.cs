﻿using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string base64String = "PEludm9pY2UgeG1sbnM9InVybjpvYXNpczpuYW1lczpzcGVjaWZpY2F0aW9uOnVibDpzY2hlbWE6eHNkOkludm9pY2UtMiIKCXhtbG5zOmNhYz0idXJuOm9hc2lzOm5hbWVzOnNwZWNpZmljYXRpb246dWJsOnNjaGVtYTp4c2Q6Q29tbW9uQWdncmVnYXRlQ29tcG9uZW50cy0yIgoJeG1sbnM6Y2JjPSJ1cm46b2FzaXM6bmFtZXM6c3BlY2lmaWNhdGlvbjp1Ymw6c2NoZW1hOnhzZDpDb21tb25CYXNpY0NvbXBvbmVudHMtMiI+Cgk8Y2JjOklEPklOVjEyMzQ1PC9jYmM6SUQ+Cgk8Y2JjOklzc3VlRGF0ZT4yMDE3LTExLTI2PC9jYmM6SXNzdWVEYXRlPgoJPGNiYzpJc3N1ZVRpbWU+MTU6MzA6MDBaPC9jYmM6SXNzdWVUaW1lPgoJPGNiYzpJbnZvaWNlVHlwZUNvZGUgbGlzdFZlcnNpb25JRD0iMS4wIj4wMTwvY2JjOkludm9pY2VUeXBlQ29kZT4KCTxjYmM6RG9jdW1lbnRDdXJyZW5jeUNvZGU+TVlSPC9jYmM6RG9jdW1lbnRDdXJyZW5jeUNvZGU+Cgk8Y2FjOkludm9pY2VQZXJpb2Q+CgkJPGNiYzpTdGFydERhdGU+MjAxNy0xMS0yNjwvY2JjOlN0YXJ0RGF0ZT4KCQk8Y2JjOkVuZERhdGU+MjAxNy0xMS0zMDwvY2JjOkVuZERhdGU+CgkJPGNiYzpEZXNjcmlwdGlvbj5Nb250aGx5PC9jYmM6RGVzY3JpcHRpb24+Cgk8L2NhYzpJbnZvaWNlUGVyaW9kPgoJPGNhYzpCaWxsaW5nUmVmZXJlbmNlPgoJCTxjYWM6QWRkaXRpb25hbERvY3VtZW50UmVmZXJlbmNlPgoJCQk8Y2JjOklEPkUxMjM0NTY3ODkxMjwvY2JjOklEPgoJCTwvY2FjOkFkZGl0aW9uYWxEb2N1bWVudFJlZmVyZW5jZT4KCTwvY2FjOkJpbGxpbmdSZWZlcmVuY2U+Cgk8Y2FjOkFkZGl0aW9uYWxEb2N1bWVudFJlZmVyZW5jZT4KCQk8Y2JjOklEPkUxMjM0NTY3ODkxMjwvY2JjOklEPgoJCTxjYmM6RG9jdW1lbnRUeXBlPkN1c3RvbXNJbXBvcnRGb3JtPC9jYmM6RG9jdW1lbnRUeXBlPgoJPC9jYWM6QWRkaXRpb25hbERvY3VtZW50UmVmZXJlbmNlPgoJPGNhYzpBZGRpdGlvbmFsRG9jdW1lbnRSZWZlcmVuY2U+CgkJPGNiYzpJRD5BU0VBTi1BdXN0cmFsaWEtTmV3IFplYWxhbmQgRlRBIChBQU5aRlRBKTwvY2JjOklEPgoJCTxjYmM6RG9jdW1lbnRUeXBlPkZyZWVUcmFkZUFncmVlbWVudDwvY2JjOkRvY3VtZW50VHlwZT4KCQk8Y2JjOkRvY3VtZW50RGVzY3JpcHRpb24+U2FtcGxlIERlc2NyaXB0aW9uPC9jYmM6RG9jdW1lbnREZXNjcmlwdGlvbj4KCTwvY2FjOkFkZGl0aW9uYWxEb2N1bWVudFJlZmVyZW5jZT4KCTxjYWM6QWRkaXRpb25hbERvY3VtZW50UmVmZXJlbmNlPgoJCTxjYmM6SUQ+RTEyMzQ1Njc4OTEyPC9jYmM6SUQ+CgkJPGNiYzpEb2N1bWVudFR5cGU+SzI8L2NiYzpEb2N1bWVudFR5cGU+Cgk8L2NhYzpBZGRpdGlvbmFsRG9jdW1lbnRSZWZlcmVuY2U+Cgk8Y2FjOkFkZGl0aW9uYWxEb2N1bWVudFJlZmVyZW5jZT4KCQk8Y2JjOklEPkNJRjwvY2JjOklEPgoJPC9jYWM6QWRkaXRpb25hbERvY3VtZW50UmVmZXJlbmNlPgoJPGNhYzpBY2NvdW50aW5nU3VwcGxpZXJQYXJ0eT4KCQk8Y2JjOkFkZGl0aW9uYWxBY2NvdW50SUQgc2NoZW1lQWdlbmN5TmFtZT0iQ2VydEVYIj5DUFQtQ0NOLVctMjExMTExLUtMLTAwMDAwMjwvY2JjOkFkZGl0aW9uYWxBY2NvdW50SUQ+CgkJPGNhYzpQYXJ0eT4KCQkJPGNiYzpJbmR1c3RyeUNsYXNzaWZpY2F0aW9uQ29kZSBuYW1lPSJHcm93aW5nIG9mIG1haXplIj4wMTExMTwvY2JjOkluZHVzdHJ5Q2xhc3NpZmljYXRpb25Db2RlPgoJCQk8Y2FjOlBhcnR5SWRlbnRpZmljYXRpb24+CgkJCQk8Y2JjOklEIHNjaGVtZUlEPSJUSU4iPkMyNTg0NTYzMjIyPC9jYmM6SUQ+CgkJCTwvY2FjOlBhcnR5SWRlbnRpZmljYXRpb24+CgkJCTxjYWM6UGFydHlJZGVudGlmaWNhdGlvbj4KCQkJCTxjYmM6SUQgc2NoZW1lSUQ9IkJSTiI+MjAyMDAxMjM0NTY3PC9jYmM6SUQ+CgkJCTwvY2FjOlBhcnR5SWRlbnRpZmljYXRpb24+CgkJCTxjYWM6UG9zdGFsQWRkcmVzcz4KCQkJCTxjYmM6Q2l0eU5hbWU+S3VhbGEgTHVtcHVyPC9jYmM6Q2l0eU5hbWU+CgkJCQk8Y2JjOlBvc3RhbFpvbmU+NTA0ODA8L2NiYzpQb3N0YWxab25lPgoJCQkJPGNiYzpDb3VudHJ5U3ViZW50aXR5Q29kZT4xNDwvY2JjOkNvdW50cnlTdWJlbnRpdHlDb2RlPgoJCQkJPGNhYzpBZGRyZXNzTGluZT4KCQkJCQk8Y2JjOkxpbmU+TG90IDY2PC9jYmM6TGluZT4KCQkJCTwvY2FjOkFkZHJlc3NMaW5lPgoJCQkJPGNhYzpBZGRyZXNzTGluZT4KCQkJCQk8Y2JjOkxpbmU+QmFuZ3VuYW4gTWVyZGVrYTwvY2JjOkxpbmU+CgkJCQk8L2NhYzpBZGRyZXNzTGluZT4KCQkJCTxjYWM6QWRkcmVzc0xpbmU+CgkJCQkJPGNiYzpMaW5lPlBlcnNpYXJhbiBKYXlhPC9jYmM6TGluZT4KCQkJCTwvY2FjOkFkZHJlc3NMaW5lPgoJCQkJPGNhYzpDb3VudHJ5PgoJCQkJCTxjYmM6SWRlbnRpZmljYXRpb25Db2RlIGxpc3RJRD0iSVNPMzE2Ni0xIiBsaXN0QWdlbmN5SUQ9IjYiPk1ZUzwvY2JjOklkZW50aWZpY2F0aW9uQ29kZT4KCQkJCTwvY2FjOkNvdW50cnk+CgkJCTwvY2FjOlBvc3RhbEFkZHJlc3M+CgkJCTxjYWM6UGFydHlMZWdhbEVudGl0eT4KCQkJCTxjYmM6UmVnaXN0cmF0aW9uTmFtZT5BTVMgU2V0aWEgSmF5YSBTZG4uIEJoZC48L2NiYzpSZWdpc3RyYXRpb25OYW1lPgoJCQk8L2NhYzpQYXJ0eUxlZ2FsRW50aXR5PgoJCQk8Y2FjOkNvbnRhY3Q+CgkJCQk8Y2JjOlRlbGVwaG9uZT4rNjAtMTIzNDU2Nzg5PC9jYmM6VGVsZXBob25lPgoJCQkJPGNiYzpFbGVjdHJvbmljTWFpbD5nZW5lcmFsLmFtc0BzdXBwbGllci5jb208L2NiYzpFbGVjdHJvbmljTWFpbD4KCQkJPC9jYWM6Q29udGFjdD4KCQk8L2NhYzpQYXJ0eT4KCTwvY2FjOkFjY291bnRpbmdTdXBwbGllclBhcnR5PgoJPGNhYzpBY2NvdW50aW5nQ3VzdG9tZXJQYXJ0eT4KCQk8Y2FjOlBhcnR5PgoJCQk8Y2FjOlBhcnR5SWRlbnRpZmljYXRpb24+CgkJCQk8Y2JjOklEIHNjaGVtZUlEPSJUSU4iPkMyNTg0NTYzMjAwPC9jYmM6SUQ+CgkJCTwvY2FjOlBhcnR5SWRlbnRpZmljYXRpb24+CgkJCTxjYWM6UGFydHlJZGVudGlmaWNhdGlvbj4KCQkJCTxjYmM6SUQgc2NoZW1lSUQ9IkJSTiI+MjAxOTAxMjM0NTY3PC9jYmM6SUQ+CgkJCTwvY2FjOlBhcnR5SWRlbnRpZmljYXRpb24+CgkJCTxjYWM6UG9zdGFsQWRkcmVzcz4KCQkJCTxjYmM6Q2l0eU5hbWU+S3VhbGEgTHVtcHVyPC9jYmM6Q2l0eU5hbWU+CgkJCQk8Y2JjOlBvc3RhbFpvbmU+NTA0ODA8L2NiYzpQb3N0YWxab25lPgoJCQkJPGNiYzpDb3VudHJ5U3ViZW50aXR5Q29kZT4xNDwvY2JjOkNvdW50cnlTdWJlbnRpdHlDb2RlPgoJCQkJPGNhYzpBZGRyZXNzTGluZT4KCQkJCQk8Y2JjOkxpbmU+TG90IDY2PC9jYmM6TGluZT4KCQkJCTwvY2FjOkFkZHJlc3NMaW5lPgoJCQkJPGNhYzpBZGRyZXNzTGluZT4KCQkJCQk8Y2JjOkxpbmU+QmFuZ3VuYW4gTWVyZGVrYTwvY2JjOkxpbmU+CgkJCQk8L2NhYzpBZGRyZXNzTGluZT4KCQkJCTxjYWM6QWRkcmVzc0xpbmU+CgkJCQkJPGNiYzpMaW5lPlBlcnNpYXJhbiBKYXlhPC9jYmM6TGluZT4KCQkJCTwvY2FjOkFkZHJlc3NMaW5lPgoJCQkJPGNhYzpDb3VudHJ5PgoJCQkJCTxjYmM6SWRlbnRpZmljYXRpb25Db2RlIGxpc3RJRD0iSVNPMzE2Ni0xIiBsaXN0QWdlbmN5SUQ9IjYiPk1ZUzwvY2JjOklkZW50aWZpY2F0aW9uQ29kZT4KCQkJCTwvY2FjOkNvdW50cnk+CgkJCTwvY2FjOlBvc3RhbEFkZHJlc3M+CgkJCTxjYWM6UGFydHlMZWdhbEVudGl0eT4KCQkJCTxjYmM6UmVnaXN0cmF0aW9uTmFtZT5IZWJhdCBHcm91cDwvY2JjOlJlZ2lzdHJhdGlvbk5hbWU+CgkJCTwvY2FjOlBhcnR5TGVnYWxFbnRpdHk+CgkJCTxjYWM6Q29udGFjdD4KCQkJCTxjYmM6VGVsZXBob25lPis2MC0xMjM0NTY3ODk8L2NiYzpUZWxlcGhvbmU+CgkJCQk8Y2JjOkVsZWN0cm9uaWNNYWlsPm5hbWVAYnV5ZXIuY29tPC9jYmM6RWxlY3Ryb25pY01haWw+CgkJCTwvY2FjOkNvbnRhY3Q+CgkJPC9jYWM6UGFydHk+Cgk8L2NhYzpBY2NvdW50aW5nQ3VzdG9tZXJQYXJ0eT4KCTxjYWM6RGVsaXZlcnk+CgkJPGNhYzpEZWxpdmVyeVBhcnR5PgoJCQk8Y2FjOlBhcnR5SWRlbnRpZmljYXRpb24+CgkJCQk8Y2JjOklEIHNjaGVtZUlEPSJUSU4iPkMyNTg0NTYzMjAwPC9jYmM6SUQ+CgkJCTwvY2FjOlBhcnR5SWRlbnRpZmljYXRpb24+CgkJCTxjYWM6UGFydHlJZGVudGlmaWNhdGlvbj4KCQkJCTxjYmM6SUQgc2NoZW1lSUQ9IkJSTiI+MjAxOTAxMjM0NTY3PC9jYmM6SUQ+CgkJCTwvY2FjOlBhcnR5SWRlbnRpZmljYXRpb24+CgkJCTxjYWM6UG9zdGFsQWRkcmVzcz4KCQkJCTxjYmM6Q2l0eU5hbWU+S3VhbGEgTHVtcHVyPC9jYmM6Q2l0eU5hbWU+CgkJCQk8Y2JjOlBvc3RhbFpvbmU+NTA0ODA8L2NiYzpQb3N0YWxab25lPgoJCQkJPGNiYzpDb3VudHJ5U3ViZW50aXR5Q29kZT4xNDwvY2JjOkNvdW50cnlTdWJlbnRpdHlDb2RlPgoJCQkJPGNhYzpBZGRyZXNzTGluZT4KCQkJCQk8Y2JjOkxpbmU+TG90IDY2PC9jYmM6TGluZT4KCQkJCTwvY2FjOkFkZHJlc3NMaW5lPgoJCQkJPGNhYzpBZGRyZXNzTGluZT4KCQkJCQk8Y2JjOkxpbmU+QmFuZ3VuYW4gTWVyZGVrYTwvY2JjOkxpbmU+CgkJCQk8L2NhYzpBZGRyZXNzTGluZT4KCQkJCTxjYWM6QWRkcmVzc0xpbmU+CgkJCQkJPGNiYzpMaW5lPlBlcnNpYXJhbiBKYXlhPC9jYmM6TGluZT4KCQkJCTwvY2FjOkFkZHJlc3NMaW5lPgoJCQkJPGNhYzpDb3VudHJ5PgoJCQkJCTxjYmM6SWRlbnRpZmljYXRpb25Db2RlIGxpc3RJRD0iSVNPMzE2Ni0xIiBsaXN0QWdlbmN5SUQ9IjYiPk1ZUzwvY2JjOklkZW50aWZpY2F0aW9uQ29kZT4KCQkJCTwvY2FjOkNvdW50cnk+CgkJCTwvY2FjOlBvc3RhbEFkZHJlc3M+CgkJCTxjYWM6UGFydHlMZWdhbEVudGl0eT4KCQkJCTxjYmM6UmVnaXN0cmF0aW9uTmFtZT5HcmVlbnogU2RuLiBCaGQuPC9jYmM6UmVnaXN0cmF0aW9uTmFtZT4KCQkJPC9jYWM6UGFydHlMZWdhbEVudGl0eT4KCQk8L2NhYzpEZWxpdmVyeVBhcnR5PgoJCTxjYWM6U2hpcG1lbnQ+CgkJCTxjYmM6SUQ+MTIzNDwvY2JjOklEPgoJCQk8Y2FjOkZyZWlnaHRBbGxvd2FuY2VDaGFyZ2U+CgkJCQk8Y2JjOkNoYXJnZUluZGljYXRvcj50cnVlPC9jYmM6Q2hhcmdlSW5kaWNhdG9yPgoJCQkJPGNiYzpBbGxvd2FuY2VDaGFyZ2VSZWFzb24+U2VydmljZSBjaGFyZ2U8L2NiYzpBbGxvd2FuY2VDaGFyZ2VSZWFzb24+CgkJCQk8Y2JjOkFtb3VudCBjdXJyZW5jeUlEPSJNWVIiPjEwMDwvY2JjOkFtb3VudD4KCQkJPC9jYWM6RnJlaWdodEFsbG93YW5jZUNoYXJnZT4KCQk8L2NhYzpTaGlwbWVudD4KCTwvY2FjOkRlbGl2ZXJ5PgoJPGNhYzpQYXltZW50TWVhbnM+CgkJPGNiYzpQYXltZW50TWVhbnNDb2RlPjAxPC9jYmM6UGF5bWVudE1lYW5zQ29kZT4KCQk8Y2FjOlBheWVlRmluYW5jaWFsQWNjb3VudD4KCQkJPGNiYzpJRD4xMjM0NTY3ODkwMTIzPC9jYmM6SUQ+CgkJPC9jYWM6UGF5ZWVGaW5hbmNpYWxBY2NvdW50PgoJPC9jYWM6UGF5bWVudE1lYW5zPgoJPGNhYzpQYXltZW50VGVybXM+CgkJPGNiYzpOb3RlPlBheW1lbnQgbWV0aG9kIGlzIGNhc2g8L2NiYzpOb3RlPgoJPC9jYWM6UGF5bWVudFRlcm1zPgoJPGNhYzpQcmVwYWlkUGF5bWVudD4KCQk8Y2JjOklEPkUxMjM0NTY3ODkxMjwvY2JjOklEPgoJCTxjYmM6UGFpZEFtb3VudCBjdXJyZW5jeUlEPSJNWVIiPjEuMDA8L2NiYzpQYWlkQW1vdW50PgoJCTxjYmM6UGFpZERhdGU+MjAwMC0wMS0wMTwvY2JjOlBhaWREYXRlPgoJCTxjYmM6UGFpZFRpbWU+MTI6MDA6MDBaPC9jYmM6UGFpZFRpbWU+Cgk8L2NhYzpQcmVwYWlkUGF5bWVudD4KCTxjYWM6QWxsb3dhbmNlQ2hhcmdlPgoJCTxjYmM6Q2hhcmdlSW5kaWNhdG9yPmZhbHNlPC9jYmM6Q2hhcmdlSW5kaWNhdG9yPgoJCTxjYmM6QWxsb3dhbmNlQ2hhcmdlUmVhc29uPlNhbXBsZSBEZXNjcmlwdGlvbjwvY2JjOkFsbG93YW5jZUNoYXJnZVJlYXNvbj4KCQk8Y2JjOkFtb3VudCBjdXJyZW5jeUlEPSJNWVIiPjEwMDwvY2JjOkFtb3VudD4KCTwvY2FjOkFsbG93YW5jZUNoYXJnZT4KCTxjYWM6QWxsb3dhbmNlQ2hhcmdlPgoJCTxjYmM6Q2hhcmdlSW5kaWNhdG9yPnRydWU8L2NiYzpDaGFyZ2VJbmRpY2F0b3I+CgkJPGNiYzpBbGxvd2FuY2VDaGFyZ2VSZWFzb24+U2VydmljZSBjaGFyZ2U8L2NiYzpBbGxvd2FuY2VDaGFyZ2VSZWFzb24+CgkJPGNiYzpBbW91bnQgY3VycmVuY3lJRD0iTVlSIj4xMDA8L2NiYzpBbW91bnQ+Cgk8L2NhYzpBbGxvd2FuY2VDaGFyZ2U+Cgk8Y2FjOlRheFRvdGFsPgoJCTxjYmM6VGF4QW1vdW50IGN1cnJlbmN5SUQ9Ik1ZUiI+ODcuNjM8L2NiYzpUYXhBbW91bnQ+CgkJPGNhYzpUYXhTdWJ0b3RhbD4KCQkJPGNiYzpUYXhhYmxlQW1vdW50IGN1cnJlbmN5SUQ9Ik1ZUiI+ODcuNjM8L2NiYzpUYXhhYmxlQW1vdW50PgoJCQk8Y2JjOlRheEFtb3VudCBjdXJyZW5jeUlEPSJNWVIiPjg3LjYzPC9jYmM6VGF4QW1vdW50PgoJCQk8Y2FjOlRheENhdGVnb3J5PgoJCQkJPGNiYzpJRD4wMTwvY2JjOklEPgoJCQkJPGNhYzpUYXhTY2hlbWU+CgkJCQkJPGNiYzpJRCBzY2hlbWVJRD0iVU4vRUNFIDUxNTMiIHNjaGVtZUFnZW5jeUlEPSI2Ij5PVEg8L2NiYzpJRD4KCQkJCTwvY2FjOlRheFNjaGVtZT4KCQkJPC9jYWM6VGF4Q2F0ZWdvcnk+CgkJPC9jYWM6VGF4U3VidG90YWw+Cgk8L2NhYzpUYXhUb3RhbD4KCTxjYWM6TGVnYWxNb25ldGFyeVRvdGFsPgoJCTxjYmM6TGluZUV4dGVuc2lvbkFtb3VudCBjdXJyZW5jeUlEPSJNWVIiPjE0MzYuNTA8L2NiYzpMaW5lRXh0ZW5zaW9uQW1vdW50PgoJCTxjYmM6VGF4RXhjbHVzaXZlQW1vdW50IGN1cnJlbmN5SUQ9Ik1ZUiI+MTQzNi41MDwvY2JjOlRheEV4Y2x1c2l2ZUFtb3VudD4KCQk8Y2JjOlRheEluY2x1c2l2ZUFtb3VudCBjdXJyZW5jeUlEPSJNWVIiPjE0MzYuNTA8L2NiYzpUYXhJbmNsdXNpdmVBbW91bnQ+CgkJPGNiYzpBbGxvd2FuY2VUb3RhbEFtb3VudCBjdXJyZW5jeUlEPSJNWVIiPjE0MzYuNTA8L2NiYzpBbGxvd2FuY2VUb3RhbEFtb3VudD4KCQk8Y2JjOkNoYXJnZVRvdGFsQW1vdW50IGN1cnJlbmN5SUQ9Ik1ZUiI+MTQzNi41MDwvY2JjOkNoYXJnZVRvdGFsQW1vdW50PgoJCTxjYmM6UGF5YWJsZVJvdW5kaW5nQW1vdW50IGN1cnJlbmN5SUQ9Ik1ZUiI+MC4zMDwvY2JjOlBheWFibGVSb3VuZGluZ0Ftb3VudD4KCQk8Y2JjOlBheWFibGVBbW91bnQgY3VycmVuY3lJRD0iTVlSIj4xNDM2LjUwPC9jYmM6UGF5YWJsZUFtb3VudD4KCTwvY2FjOkxlZ2FsTW9uZXRhcnlUb3RhbD4KCTxjYWM6SW52b2ljZUxpbmU+CgkJPGNiYzpJRD4xMjM0PC9jYmM6SUQ+CgkJPGNiYzpJbnZvaWNlZFF1YW50aXR5IHVuaXRDb2RlPSJDNjIiPjE8L2NiYzpJbnZvaWNlZFF1YW50aXR5PgoJCTxjYmM6TGluZUV4dGVuc2lvbkFtb3VudCBjdXJyZW5jeUlEPSJNWVIiPjE0MzYuNTA8L2NiYzpMaW5lRXh0ZW5zaW9uQW1vdW50PgoJCTxjYWM6QWxsb3dhbmNlQ2hhcmdlPgoJCQk8Y2JjOkNoYXJnZUluZGljYXRvcj5mYWxzZTwvY2JjOkNoYXJnZUluZGljYXRvcj4KCQkJPGNiYzpBbGxvd2FuY2VDaGFyZ2VSZWFzb24+U2FtcGxlIERlc2NyaXB0aW9uPC9jYmM6QWxsb3dhbmNlQ2hhcmdlUmVhc29uPgoJCQk8Y2JjOk11bHRpcGxpZXJGYWN0b3JOdW1lcmljPjAuMTU8L2NiYzpNdWx0aXBsaWVyRmFjdG9yTnVtZXJpYz4KCQkJPGNiYzpBbW91bnQgY3VycmVuY3lJRD0iTVlSIj4xMDA8L2NiYzpBbW91bnQ+CgkJPC9jYWM6QWxsb3dhbmNlQ2hhcmdlPgoJCTxjYWM6QWxsb3dhbmNlQ2hhcmdlPgoJCQk8Y2JjOkNoYXJnZUluZGljYXRvcj50cnVlPC9jYmM6Q2hhcmdlSW5kaWNhdG9yPgoJCQk8Y2JjOkFsbG93YW5jZUNoYXJnZVJlYXNvbj5TYW1wbGUgRGVzY3JpcHRpb248L2NiYzpBbGxvd2FuY2VDaGFyZ2VSZWFzb24+CgkJCTxjYmM6TXVsdGlwbGllckZhY3Rvck51bWVyaWM+MC4xMDwvY2JjOk11bHRpcGxpZXJGYWN0b3JOdW1lcmljPgoJCQk8Y2JjOkFtb3VudCBjdXJyZW5jeUlEPSJNWVIiPjEwMDwvY2JjOkFtb3VudD4KCQk8L2NhYzpBbGxvd2FuY2VDaGFyZ2U+CgkJPGNhYzpUYXhUb3RhbD4KCQkJPGNiYzpUYXhBbW91bnQgY3VycmVuY3lJRD0iTVlSIj4xNDYwLjUwPC9jYmM6VGF4QW1vdW50PgoJCQk8Y2FjOlRheFN1YnRvdGFsPgoJCQkJPGNiYzpUYXhhYmxlQW1vdW50IGN1cnJlbmN5SUQ9Ik1ZUiI+MTQ2MC41MDwvY2JjOlRheGFibGVBbW91bnQ+CgkJCQk8Y2JjOlRheEFtb3VudCBjdXJyZW5jeUlEPSJNWVIiPjA8L2NiYzpUYXhBbW91bnQ+CgkJCQk8Y2FjOlRheENhdGVnb3J5PgoJCQkJCTxjYmM6SUQ+RTwvY2JjOklEPgoJCQkJCTxjYmM6UGVyY2VudD42LjAwPC9jYmM6UGVyY2VudD4KCQkJCQk8Y2JjOlRheEV4ZW1wdGlvblJlYXNvbj5FeGVtcHQgTmV3IE1lYW5zIG9mIFRyYW5zcG9ydDwvY2JjOlRheEV4ZW1wdGlvblJlYXNvbj4KCQkJCQk8Y2FjOlRheFNjaGVtZT4KCQkJCQkJPGNiYzpJRCBzY2hlbWVJRD0iVU4vRUNFIDUxNTMiIHNjaGVtZUFnZW5jeUlEPSI2Ij5PVEg8L2NiYzpJRD4KCQkJCQk8L2NhYzpUYXhTY2hlbWU+CgkJCQk8L2NhYzpUYXhDYXRlZ29yeT4KCQkJPC9jYWM6VGF4U3VidG90YWw+CgkJPC9jYWM6VGF4VG90YWw+CgkJPGNhYzpJdGVtPgoJCQk8Y2JjOkRlc2NyaXB0aW9uPkxhcHRvcCBQZXJpcGhlcmFsczwvY2JjOkRlc2NyaXB0aW9uPgoJCQk8Y2FjOk9yaWdpbkNvdW50cnk+CgkJCQk8Y2JjOklkZW50aWZpY2F0aW9uQ29kZT5NWVM8L2NiYzpJZGVudGlmaWNhdGlvbkNvZGU+CgkJCTwvY2FjOk9yaWdpbkNvdW50cnk+CgkJCTxjYWM6Q29tbW9kaXR5Q2xhc3NpZmljYXRpb24+CgkJCQk8Y2JjOkl0ZW1DbGFzc2lmaWNhdGlvbkNvZGUgbGlzdElEPSJQVEMiPjEyMzQ0MzIxPC9jYmM6SXRlbUNsYXNzaWZpY2F0aW9uQ29kZT4KCQkJPC9jYWM6Q29tbW9kaXR5Q2xhc3NpZmljYXRpb24+CgkJCTxjYWM6Q29tbW9kaXR5Q2xhc3NpZmljYXRpb24+CgkJCQk8Y2JjOkl0ZW1DbGFzc2lmaWNhdGlvbkNvZGUgbGlzdElEPSJDTEFTUyI+MTIzNDQzMjE8L2NiYzpJdGVtQ2xhc3NpZmljYXRpb25Db2RlPgoJCQk8L2NhYzpDb21tb2RpdHlDbGFzc2lmaWNhdGlvbj4KCQk8L2NhYzpJdGVtPgoJCTxjYWM6UHJpY2U+CgkJCTxjYmM6UHJpY2VBbW91bnQgY3VycmVuY3lJRD0iTVlSIj4xNzwvY2JjOlByaWNlQW1vdW50PgoJCTwvY2FjOlByaWNlPgoJCTxjYWM6SXRlbVByaWNlRXh0ZW5zaW9uPgoJCQk8Y2JjOkFtb3VudCBjdXJyZW5jeUlEPSJNWVIiPjEwMDwvY2JjOkFtb3VudD4KCQk8L2NhYzpJdGVtUHJpY2VFeHRlbnNpb24+Cgk8L2NhYzpJbnZvaWNlTGluZT4KPC9JbnZvaWNlPg=="; // Replace with your Base64 string
        byte[] fileBytes = Convert.FromBase64String(base64String);

        // Specify the output file path
        string outputPath = "output.txt"; // Change as needed
        File.WriteAllBytes(outputPath, fileBytes);

        Console.WriteLine("File has been written to " + outputPath);
    }
}
