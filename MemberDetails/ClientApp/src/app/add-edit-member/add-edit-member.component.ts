import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MemberService } from '../services/member.service';


@Component({
  selector: 'app-add-edit-member',
  templateUrl: './add-edit-member.component.html',
  styleUrls: ['./add-edit-member.component.css']
})
export class AddEditMemberComponent implements OnInit {

  public memberForm = new FormGroup({
    id: new FormControl(''),
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    middleName: new FormControl(''),
    gender: new FormControl('', [Validators.required]),
    age: new FormControl('', [Validators.required]),
  });

  public memberId: string;
  public isFormSubmitted: boolean = false;

  constructor(private _activatedRoute: ActivatedRoute, private memberService: MemberService, private router: Router) {

  }

  ngOnInit() {
    this.memberId = this._activatedRoute.snapshot.paramMap.get('id');

    if (this.memberId) {
      this.memberService.getMemberById(this.memberId).subscribe((member: Member) => {
        this.memberForm = new FormGroup({
          id: new FormControl(member.id),
          firstName: new FormControl(member.firstName, [Validators.required]),
          lastName: new FormControl(member.lastName, [Validators.required]),
          middleName: new FormControl(member.middleName),
          gender: new FormControl(member.gender, [Validators.required]),
          age: new FormControl(member.age, [Validators.required, Validators.minLength(1)]),
        })
      })  
    }

  }

  onSubmit() {
    this.isFormSubmitted = true;
    if (!this.memberForm.invalid) {
      if (this.memberId) {
        this.memberService.updateMember(this.memberForm.value).subscribe(data => {
          this.router.navigate(['/']);
        })
      }
      else {
        this.memberService.addMember(this.memberForm.value).subscribe(data => {
          this.router.navigate(['/']);
        })
      }
      this.isFormSubmitted = false;
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }

}
