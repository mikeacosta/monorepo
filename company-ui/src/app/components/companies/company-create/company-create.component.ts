import { Component } from '@angular/core';
import { CompanyService } from '../../../services/company.service';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company-create',
  standalone: false,
  
  templateUrl: './company-create.component.html',
  styleUrl: './company-create.component.css'
})
export class CompanyCreateComponent {
  form!: FormGroup;

  constructor(
    private companyService: CompanyService,
    private router: Router
  ) {
      this.initForm();
  }

  initForm(): void {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      address: new FormGroup({
        address1: new FormControl('', Validators.required),
        address2: new FormControl(''),
        city: new FormControl('', Validators.required),
        state: new FormControl(''),
        postalCode: new FormControl(''),
        country: new FormControl('', Validators.required),
      }),
      contacts: new FormArray([
        this.createContactForm()
      ])    
    });
  }

  createContactForm(): FormGroup {
    return new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('')
    })
  }

  getContactFormArray(): FormArray {
    return this.form.get('contacts') as FormArray;
  }

  // getContactForm(index: number): FormGroup {
  //   return this.getContactFormArray().controls.at(index) as FormGroup;
  // }

  onSubmit() {
    if (this.form.valid) {
      this.companyService.post(this.form.value).subscribe(
        data => {
          this.router.navigate(['/companies/']);
        },
        error => {
          alert("An error occurred, please try again");
          console.error("ERROR:", error);
        }
      )
    } else {
      alert("Please fill all required fields");
    }
  }
}
