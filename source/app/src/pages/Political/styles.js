import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';

export default StyleSheet.create({
    container: {
        flex: 1,
        paddingHorizontal: 16,
        paddingTop: Constants.statusBarHeight + 20,
    },
    
     politicalProfile: {
        alignItems: 'center',
     },

     avatar: {
        width: 120,
        height: 120,
        borderRadius: 60,
        marginRight: 12,
     },

     personalText: {
        alignItems: 'center',
     },
    
     politicalName: {
         fontSize: 24,
         color: '#41414d',
         fontWeight: 'bold',
     },

     politicalOffice: {
        fontSize: 18,
        color: '#00B0F0',
        fontWeight: 'bold',
     },

     socialInteraction: {
         marginTop: 12,
         marginBottom: 12, 
         flexDirection: 'row',
         justifyContent: 'space-between',
     },

     followers: {
        flexDirection: 'row',
        alignItems: 'center',
        paddingHorizontal: 16,
     },

     followersText: {
        marginLeft: 8,
     },

     follow: {
        alignItems: 'center',
        backgroundColor: '#2c3b79',
        paddingHorizontal: 4,
        paddingVertical: 1,
        borderRadius: 8,
     },

     followText: {
        color: '#fff' ,
     },

     answers: {
         flexDirection: 'row',
        alignItems: 'center',
        paddingHorizontal: 16,
     },

     answersText: {
        marginLeft: 8,
     },

     post: {
        padding: 24,
        borderRadius: 8,
        backgroundColor: '#fff',
        marginBottom: 16,
     }, 

     title: {
        marginBottom: 4,
        fontSize: 16,
        color: '#41414d',
        fontWeight: 'bold',
     },

     postVoting: {
         marginTop: 12,
         flexDirection: 'row',
         justifyContent: 'space-between',
         alignItems: 'center',
     },

     detailsButtonYes: {
         flexDirection: 'row',
         justifyContent: 'space-between',
         alignItems: 'center',
         paddingVertical: 8,
         paddingHorizontal: 45,
         borderRadius: 8,
         backgroundColor: "#b1ecd5",
     },

     detailsButtonNo: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        alignItems: 'center',
        paddingVertical: 8,
        paddingHorizontal: 45,
        borderRadius: 8,
        backgroundColor: "#ffc0cb",
    },

    detailsButtonText: {
        fontSize: 14,
        fontWeight: 'bold',
    },
});