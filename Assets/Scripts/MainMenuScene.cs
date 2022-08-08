using InstantGamesBridge;
using InstantGamesBridge.Modules.Social;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScene : MonoBehaviour
{
	[SerializeField] private GameObject _buttonFriends;	
	[SerializeField] private GameObject _buttonFavorite;	
	[SerializeField] private GameObject _buttonPublic;	
	[SerializeField] private GameObject _buttonWall;	

	private void Start()
	{
		_buttonFriends.SetActive(Bridge.social.isInviteFriendsSupported);
		_buttonFavorite.SetActive(Bridge.social.isAddToFavoritesSupported);
		_buttonPublic.SetActive(Bridge.social.isJoinCommunitySupported);
		_buttonWall.SetActive(Bridge.social.isCreatePostSupported);
	}

	public void OnButtonClickInviteFriends()
    {
		Bridge.social.InviteFriends(success =>
		{
			if (success)
			{
				Debug.Log("InviteFriends");
			}
			else
			{
				Debug.Log("Error InviteFriends");
			}
		});
	}

	public void OnButtonClickAddFavorites()
	{
		Bridge.social.AddToFavorites(success =>
		{
			if (success)
			{
				Debug.Log("Favorites");
			}
			else
			{
				Debug.Log("Error Favorites");
			}
		});
	}

	public void OnButtonClickJoinPublic()
	{
		var vkGroupId = 214584723;
		Bridge.social.JoinCommunity(success =>
		{
			if (success)
			{
				Debug.Log("JoinPublic");
			}
			else
			{
				Debug.Log("Error JoinPublic");
			}
		},
		new JoinCommunityVkOptions(vkGroupId));
	}

	public void OnButtonClickPostWall()
	{
		var vkPostMessage = "Клевая игра, вступайте! https://vk.com/app8219725";
		var vkPostAttachments = "photo27793022_457239419";
		Bridge.social.CreatePost(success =>
		{
			if (success)
			{
				Debug.Log("PostWall");
			}
			else
			{
				Debug.Log("Error PostWall");
			}
		},
		new CreatePostVkOptions(vkPostMessage, vkPostAttachments));
	}
}
