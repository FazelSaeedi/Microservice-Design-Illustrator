import { outputAst } from '@angular/compiler';
import { Component, ElementRef, OnInit, Output , EventEmitter } from '@angular/core';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {


  @Output() onClose = new EventEmitter();


  @Output() countChanged: EventEmitter<number> =  new EventEmitter();


  constructor(private el: ElementRef) {
    //console.log(el.nativeElement);
  }
  ngOnInit(): void {
    document.body.appendChild(this.el.nativeElement);
  }
  ngOnDestroy(): void {
    this.el.nativeElement.remove();
  }


  onCloseClick()  {
     this.onClose.emit();
  }

  onSubmit(){
    this.countChanged.emit(15);
    this.onClose.emit();
  }
}
