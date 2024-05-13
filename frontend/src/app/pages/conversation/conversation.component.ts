import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IConversation } from '@app/features/messenger/interfaces/IConversation';
import { ConversationService } from '@app/features/messenger/services/conversation.service';

@Component({
  selector: 'app-conversation',
  standalone: true,
  imports: [],
  templateUrl: './conversation.component.html',
  styleUrl: './conversation.component.scss',
})
export class ConversationComponent implements OnInit {
  public conversations!: IConversation[];

  private conversationsService = inject(ConversationService);
  private activatedRoute = inject(ActivatedRoute);

  ngOnInit() {
    this.conversationsService.getConversations().subscribe((response) => {
      console.log(response)
      this.conversations = response;
    });
  }
}
