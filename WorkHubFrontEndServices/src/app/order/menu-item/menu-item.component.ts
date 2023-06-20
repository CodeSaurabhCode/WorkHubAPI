import { Component, Input } from '@angular/core';
import { Item } from 'src/app/shared/models/items';

@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.scss']
})
export class MenuItemComponent {
  @Input() item? : Item;
}
