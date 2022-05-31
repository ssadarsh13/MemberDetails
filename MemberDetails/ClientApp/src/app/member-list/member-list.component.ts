import { Component, OnInit, OnDestroy } from '@angular/core';
import { MemberService } from '../services/member.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit, OnDestroy {
  public members: Member[];
  constructor(private memberService : MemberService,private router: Router) { }

  ngOnInit() {
    this.memberService.getAllMembers().subscribe(data =>{
      this.members = data;
    })
  }

  editMember(member : Member){
    this.router.navigate(
      ['edit-member',member.id]
    );
  }

  addMember(){
    this.router.navigate(
      ['add-member']
    );
  }

  deleteMember(memberId: string){
    this.memberService.deleteMember(memberId).subscribe(data =>{
         this.ngOnInit();
    })
  }

  ngOnDestroy(): void {
    
  }
  
}
