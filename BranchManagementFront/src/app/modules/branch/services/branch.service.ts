import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Branch } from 'src/app/models/branch.model.model';

@Injectable({
  providedIn: 'root'
})
export class BranchService {

  private apiUrl = 'https://localhost:7226/api/Branch';

  constructor(private http: HttpClient) { }

  //getBranches(): Observable<Branch[]> {
  //  return this.http.get<Branch[]>(this.apiUrl);
  //}
  

  getBranches(filter: string, page: number, pageSize: number) {
    console.log(filter)
    var params;
    if (filter) {
       params = {

        pageNo: page.toString(),
        pageSize: pageSize.toString(),

        title: filter
      }
    }
    else {
       params = {

        pageNo: page.toString(),
        pageSize: pageSize.toString()
      };
    }
   
    return this.http.get<any>(`${this.apiUrl}/GetAllBranches`, { params });
    
  }
  getBranchById(id: number): Observable<Branch> {
    return this.http.get<Branch>(`${this.apiUrl}/${id}`);
  }
  addBranch(branch: Branch): Observable<Branch> {
    return this.http.post<Branch>(this.apiUrl, branch);
  }

  updateBranch(id: number, branch: Branch): Observable<Branch> {
    branch.id = id;
    return this.http.put<Branch>(`${this.apiUrl}/${id}`, branch);
  }

  deleteBranch(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
