import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form!: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  private validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha', 'confirmeSenha')
    };

    this.form = this.fb.group({
      primeiroNome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      ultimoNome: ['', Validators.required],
      email: ['',
        Validators.required, Validators.email
      ],
      userName: ['', [Validators.required, Validators.max(2000)]],
      senha: ['',
        Validators.required, Validators.minLength(6)
      ],
      confirmeSenha: ['', [Validators.required]],
    }, formOptions);
  }
}
