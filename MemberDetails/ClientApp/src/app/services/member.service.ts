import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import {  map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  
  constructor(private http: HttpClient) {
    
  }

  public getAllMembers(): Observable<Member[]> {
    return this.http.get(`${environment.baseApiUrl}/members`).pipe(map((res: Member[]) => res));
  }

  public getMemberById(memberId: string): Observable<Member> {
    return this.http.get(`${environment.baseApiUrl}/members/${memberId}`).pipe(map((res: Member) => res));
  }

  public updateMember(member: Member): Observable<Member> {
    return this.http.put(`${environment.baseApiUrl}/members/${member.id}`,member).pipe(map((res: Member) => res));
  }

  public deleteMember(memberId: string): Observable<Member> {
    return this.http.delete(`${environment.baseApiUrl}/members/${memberId}`).pipe(map((res: Member) => res));
  }

  public addMember(member: Member): Observable<Member> {
    return this.http.post(`${environment.baseApiUrl}/members`,member).pipe(map((res: Member) => res));
  }
}


